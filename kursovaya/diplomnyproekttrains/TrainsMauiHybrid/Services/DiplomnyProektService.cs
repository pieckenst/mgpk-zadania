using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using DevExpress.Data.Linq.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Radzen;


using TrainsMauiHybrid.Data;

namespace TrainsMauiHybrid.Services
{
    public partial class DiplomnyProektService
    {
        DiplomnyProektContext Context
        {
            get
            {
                return this.context;
            }
        }

        private readonly DiplomnyProektContext context;
        private readonly NavigationManager navigationManager;

        public DiplomnyProektService(DiplomnyProektContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);

        public void ApplyQuery<T>(ref IQueryable<T> items, Query query = null)
        {
            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }
        }


        public async Task ExportBiletiesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/diplomnyproekt/bileties/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/diplomnyproekt/bileties/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBiletiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/diplomnyproekt/bileties/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/diplomnyproekt/bileties/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBiletiesRead(ref IQueryable<TrainsMauiHybrid.Models.Bilety> items);

        public async Task<IQueryable<TrainsMauiHybrid.Models.Bilety>> GetBileties(Query query = null)
        {
            var items = Context.Bileties.AsQueryable();

            items = items.Include(i => i.Marshuti);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach (var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnBiletiesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnBiletyGet(TrainsMauiHybrid.Models.Bilety item);
        partial void OnGetBiletyByNomerBileta(ref IQueryable<TrainsMauiHybrid.Models.Bilety> items);


        public async Task<TrainsMauiHybrid.Models.Bilety> GetBiletyByNomerBileta(long nomerbileta)
        {
            var items = Context.Bileties
                              .AsNoTracking()
                              .Where(i => i.Nomer_Bileta == nomerbileta);

            items = items.Include(i => i.Marshuti);

            OnGetBiletyByNomerBileta(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnBiletyGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnBiletyCreated(TrainsMauiHybrid.Models.Bilety item);
        partial void OnAfterBiletyCreated(TrainsMauiHybrid.Models.Bilety item);

        public async Task<TrainsMauiHybrid.Models.Bilety> CreateBilety(TrainsMauiHybrid.Models.Bilety bilety)
        {
            OnBiletyCreated(bilety);

            var existingItem = Context.Bileties
                              .Where(i => i.Nomer_Bileta == bilety.Nomer_Bileta)
                              .FirstOrDefault();

            if (existingItem != null)
            {
                throw new Exception("Item already available");
            }

            try
            {
                Context.Bileties.Add(bilety);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(bilety).State = EntityState.Detached;
                throw;
            }

            OnAfterBiletyCreated(bilety);

            return bilety;
        }

        public async Task<TrainsMauiHybrid.Models.Bilety> CancelBiletyChanges(TrainsMauiHybrid.Models.Bilety item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
                entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
                entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnBiletyUpdated(TrainsMauiHybrid.Models.Bilety item);
        partial void OnAfterBiletyUpdated(TrainsMauiHybrid.Models.Bilety item);

        public async Task<TrainsMauiHybrid.Models.Bilety> UpdateBilety(long nomerbileta, TrainsMauiHybrid.Models.Bilety bilety)
        {
            OnBiletyUpdated(bilety);

            var itemToUpdate = Context.Bileties
                              .Where(i => i.Nomer_Bileta == bilety.Nomer_Bileta)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
                throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(bilety);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterBiletyUpdated(bilety);

            return bilety;
        }

        partial void OnBiletyDeleted(TrainsMauiHybrid.Models.Bilety item);
        partial void OnAfterBiletyDeleted(TrainsMauiHybrid.Models.Bilety item);

        public async Task<TrainsMauiHybrid.Models.Bilety> DeleteBilety(long nomerbileta)
        {
            var itemToDelete = Context.Bileties
                              .Where(i => i.Nomer_Bileta == nomerbileta)
                              .Include(i => i.Prodazhis)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
                throw new Exception("Item no longer available");
            }

            OnBiletyDeleted(itemToDelete);


            Context.Bileties.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterBiletyDeleted(itemToDelete);

            return itemToDelete;
        }

        public async Task ExportEmployeesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/diplomnyproekt/employees/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/diplomnyproekt/employees/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportEmployeesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/diplomnyproekt/employees/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/diplomnyproekt/employees/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnEmployeesRead(ref IQueryable<TrainsMauiHybrid.Models.Employee> items);

        public async Task<IQueryable<TrainsMauiHybrid.Models.Employee>> GetEmployees(Query query = null)
        {
            var items = Context.Employees.AsQueryable();

            items = items.Include(i => i.Job);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach (var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnEmployeesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnEmployeeGet(TrainsMauiHybrid.Models.Employee item);
        partial void OnGetEmployeeByNum(ref IQueryable<TrainsMauiHybrid.Models.Employee> items);


        public async Task<TrainsMauiHybrid.Models.Employee> GetEmployeeByNum(long num)
        {
            var items = Context.Employees
                              .AsNoTracking()
                              .Where(i => i.Num == num);

            items = items.Include(i => i.Job);

            OnGetEmployeeByNum(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnEmployeeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnEmployeeCreated(TrainsMauiHybrid.Models.Employee item);
        partial void OnAfterEmployeeCreated(TrainsMauiHybrid.Models.Employee item);

        public async Task<TrainsMauiHybrid.Models.Employee> CreateEmployee(TrainsMauiHybrid.Models.Employee employee)
        {
            OnEmployeeCreated(employee);

            var existingItem = Context.Employees
                              .Where(i => i.Num == employee.Num)
                              .FirstOrDefault();

            if (existingItem != null)
            {
                throw new Exception("Item already available");
            }

            try
            {
                Context.Employees.Add(employee);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(employee).State = EntityState.Detached;
                throw;
            }

            OnAfterEmployeeCreated(employee);

            return employee;
        }

        public async Task<TrainsMauiHybrid.Models.Employee> CancelEmployeeChanges(TrainsMauiHybrid.Models.Employee item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
                entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
                entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnEmployeeUpdated(TrainsMauiHybrid.Models.Employee item);
        partial void OnAfterEmployeeUpdated(TrainsMauiHybrid.Models.Employee item);

        public async Task<TrainsMauiHybrid.Models.Employee> UpdateEmployee(long num, TrainsMauiHybrid.Models.Employee employee)
        {
            OnEmployeeUpdated(employee);

            var itemToUpdate = Context.Employees
                              .Where(i => i.Num == employee.Num)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
                throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(employee);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterEmployeeUpdated(employee);

            return employee;
        }

        partial void OnEmployeeDeleted(TrainsMauiHybrid.Models.Employee item);
        partial void OnAfterEmployeeDeleted(TrainsMauiHybrid.Models.Employee item);

        public async Task<TrainsMauiHybrid.Models.Employee> DeleteEmployee(long num)
        {
            var itemToDelete = Context.Employees
                              .Where(i => i.Num == num)
                              .Include(i => i.Marshutis)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
                throw new Exception("Item no longer available");
            }

            OnEmployeeDeleted(itemToDelete);


            Context.Employees.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterEmployeeDeleted(itemToDelete);

            return itemToDelete;
        }

        public async Task ExportJobsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/diplomnyproekt/jobs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/diplomnyproekt/jobs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportJobsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/diplomnyproekt/jobs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/diplomnyproekt/jobs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnJobsRead(ref IQueryable<TrainsMauiHybrid.Models.Job> items);

        public async Task<IQueryable<TrainsMauiHybrid.Models.Job>> GetJobs(Query query = null)
        {
            var items = Context.Jobs.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach (var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnJobsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnJobGet(TrainsMauiHybrid.Models.Job item);
        partial void OnGetJobByJobNum(ref IQueryable<TrainsMauiHybrid.Models.Job> items);


        public async Task<TrainsMauiHybrid.Models.Job> GetJobByJobNum(long jobnum)
        {
            var items = Context.Jobs
                              .AsNoTracking()
                              .Where(i => i.Job_Num == jobnum);


            OnGetJobByJobNum(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnJobGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnJobCreated(TrainsMauiHybrid.Models.Job item);
        partial void OnAfterJobCreated(TrainsMauiHybrid.Models.Job item);

        public async Task<TrainsMauiHybrid.Models.Job> CreateJob(TrainsMauiHybrid.Models.Job job)
        {
            OnJobCreated(job);

            var existingItem = Context.Jobs
                              .Where(i => i.Job_Num == job.Job_Num)
                              .FirstOrDefault();

            if (existingItem != null)
            {
                throw new Exception("Item already available");
            }

            try
            {
                Context.Jobs.Add(job);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(job).State = EntityState.Detached;
                throw;
            }

            OnAfterJobCreated(job);

            return job;
        }

        public async Task<TrainsMauiHybrid.Models.Job> CancelJobChanges(TrainsMauiHybrid.Models.Job item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
                entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
                entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnJobUpdated(TrainsMauiHybrid.Models.Job item);
        partial void OnAfterJobUpdated(TrainsMauiHybrid.Models.Job item);

        public async Task<TrainsMauiHybrid.Models.Job> UpdateJob(long jobnum, TrainsMauiHybrid.Models.Job job)
        {
            OnJobUpdated(job);

            var itemToUpdate = Context.Jobs
                              .Where(i => i.Job_Num == job.Job_Num)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
                throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(job);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterJobUpdated(job);

            return job;
        }

        partial void OnJobDeleted(TrainsMauiHybrid.Models.Job item);
        partial void OnAfterJobDeleted(TrainsMauiHybrid.Models.Job item);

        public async Task<TrainsMauiHybrid.Models.Job> DeleteJob(long jobnum)
        {
            var itemToDelete = Context.Jobs
                              .Where(i => i.Job_Num == jobnum)
                              .Include(i => i.Employees)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
                throw new Exception("Item no longer available");
            }

            OnJobDeleted(itemToDelete);


            Context.Jobs.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterJobDeleted(itemToDelete);

            return itemToDelete;
        }

        public async Task ExportMarshutisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/diplomnyproekt/marshutis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/diplomnyproekt/marshutis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportMarshutisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/diplomnyproekt/marshutis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/diplomnyproekt/marshutis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnMarshutisRead(ref IQueryable<TrainsMauiHybrid.Models.Marshuti> items);

        public async Task<IQueryable<TrainsMauiHybrid.Models.Marshuti>> GetMarshutis(Query query = null)
        {
            var items = Context.Marshutis.AsQueryable();

            items = items.Include(i => i.Employee);
            items = items.Include(i => i.Train);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach (var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnMarshutisRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnMarshutiGet(TrainsMauiHybrid.Models.Marshuti item);
        partial void OnGetMarshutiByNomerMarshuta(ref IQueryable<TrainsMauiHybrid.Models.Marshuti> items);


        public async Task<TrainsMauiHybrid.Models.Marshuti> GetMarshutiByNomerMarshuta(long nomermarshuta)
        {
            var items = Context.Marshutis
                              .AsNoTracking()
                              .Where(i => i.Nomer_Marshuta == nomermarshuta);

            items = items.Include(i => i.Employee);
            items = items.Include(i => i.Train);

            OnGetMarshutiByNomerMarshuta(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnMarshutiGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnMarshutiCreated(TrainsMauiHybrid.Models.Marshuti item);
        partial void OnAfterMarshutiCreated(TrainsMauiHybrid.Models.Marshuti item);

        public async Task<TrainsMauiHybrid.Models.Marshuti> CreateMarshuti(TrainsMauiHybrid.Models.Marshuti marshuti)
        {
            OnMarshutiCreated(marshuti);

            var existingItem = Context.Marshutis
                              .Where(i => i.Nomer_Marshuta == marshuti.Nomer_Marshuta)
                              .FirstOrDefault();

            if (existingItem != null)
            {
                throw new Exception("Item already available");
            }

            try
            {
                Context.Marshutis.Add(marshuti);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(marshuti).State = EntityState.Detached;
                throw;
            }

            OnAfterMarshutiCreated(marshuti);

            return marshuti;
        }

        public async Task<TrainsMauiHybrid.Models.Marshuti> CancelMarshutiChanges(TrainsMauiHybrid.Models.Marshuti item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
                entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
                entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnMarshutiUpdated(TrainsMauiHybrid.Models.Marshuti item);
        partial void OnAfterMarshutiUpdated(TrainsMauiHybrid.Models.Marshuti item);

        public async Task<TrainsMauiHybrid.Models.Marshuti> UpdateMarshuti(long nomermarshuta, TrainsMauiHybrid.Models.Marshuti marshuti)
        {
            OnMarshutiUpdated(marshuti);

            var itemToUpdate = Context.Marshutis
                              .Where(i => i.Nomer_Marshuta == marshuti.Nomer_Marshuta)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
                throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(marshuti);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterMarshutiUpdated(marshuti);

            return marshuti;
        }

        partial void OnMarshutiDeleted(TrainsMauiHybrid.Models.Marshuti item);
        partial void OnAfterMarshutiDeleted(TrainsMauiHybrid.Models.Marshuti item);

        public async Task<TrainsMauiHybrid.Models.Marshuti> DeleteMarshuti(long nomermarshuta)
        {
            var itemToDelete = Context.Marshutis
                              .Where(i => i.Nomer_Marshuta == nomermarshuta)
                              .Include(i => i.Bileties)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
                throw new Exception("Item no longer available");
            }

            OnMarshutiDeleted(itemToDelete);


            Context.Marshutis.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterMarshutiDeleted(itemToDelete);

            return itemToDelete;
        }

        public async Task ExportObsluzhivaniesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/diplomnyproekt/obsluzhivanies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/diplomnyproekt/obsluzhivanies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportObsluzhivaniesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/diplomnyproekt/obsluzhivanies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/diplomnyproekt/obsluzhivanies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnObsluzhivaniesRead(ref IQueryable<TrainsMauiHybrid.Models.Obsluzhivanie> items);

        public async Task<IQueryable<TrainsMauiHybrid.Models.Obsluzhivanie>> GetObsluzhivanies(Query query = null)
        {
            var items = Context.Obsluzhivanies.AsQueryable();

            items = items.Include(i => i.Train);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach (var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnObsluzhivaniesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnObsluzhivanieGet(TrainsMauiHybrid.Models.Obsluzhivanie item);
        partial void OnGetObsluzhivanieByNomerObsluzhivania(ref IQueryable<TrainsMauiHybrid.Models.Obsluzhivanie> items);


        public async Task<TrainsMauiHybrid.Models.Obsluzhivanie> GetObsluzhivanieByNomerObsluzhivania(long nomerobsluzhivania)
        {
            var items = Context.Obsluzhivanies
                              .AsNoTracking()
                              .Where(i => i.NomerObsluzhivania == nomerobsluzhivania);

            items = items.Include(i => i.Train);

            OnGetObsluzhivanieByNomerObsluzhivania(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnObsluzhivanieGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnObsluzhivanieCreated(TrainsMauiHybrid.Models.Obsluzhivanie item);
        partial void OnAfterObsluzhivanieCreated(TrainsMauiHybrid.Models.Obsluzhivanie item);

        public async Task<TrainsMauiHybrid.Models.Obsluzhivanie> CreateObsluzhivanie(TrainsMauiHybrid.Models.Obsluzhivanie obsluzhivanie)
        {
            OnObsluzhivanieCreated(obsluzhivanie);

            var existingItem = Context.Obsluzhivanies
                              .Where(i => i.NomerObsluzhivania == obsluzhivanie.NomerObsluzhivania)
                              .FirstOrDefault();

            if (existingItem != null)
            {
                throw new Exception("Item already available");
            }

            try
            {
                Context.Obsluzhivanies.Add(obsluzhivanie);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(obsluzhivanie).State = EntityState.Detached;
                throw;
            }

            OnAfterObsluzhivanieCreated(obsluzhivanie);

            return obsluzhivanie;
        }

        public async Task<TrainsMauiHybrid.Models.Obsluzhivanie> CancelObsluzhivanieChanges(TrainsMauiHybrid.Models.Obsluzhivanie item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
                entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
                entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnObsluzhivanieUpdated(TrainsMauiHybrid.Models.Obsluzhivanie item);
        partial void OnAfterObsluzhivanieUpdated(TrainsMauiHybrid.Models.Obsluzhivanie item);

        public async Task<TrainsMauiHybrid.Models.Obsluzhivanie> UpdateObsluzhivanie(long nomerobsluzhivania, TrainsMauiHybrid.Models.Obsluzhivanie obsluzhivanie)
        {
            OnObsluzhivanieUpdated(obsluzhivanie);

            var itemToUpdate = Context.Obsluzhivanies
                              .Where(i => i.NomerObsluzhivania == obsluzhivanie.NomerObsluzhivania)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
                throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(obsluzhivanie);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterObsluzhivanieUpdated(obsluzhivanie);

            return obsluzhivanie;
        }

        partial void OnObsluzhivanieDeleted(TrainsMauiHybrid.Models.Obsluzhivanie item);
        partial void OnAfterObsluzhivanieDeleted(TrainsMauiHybrid.Models.Obsluzhivanie item);

        public async Task<TrainsMauiHybrid.Models.Obsluzhivanie> DeleteObsluzhivanie(long nomerobsluzhivania)
        {
            var itemToDelete = Context.Obsluzhivanies
                              .Where(i => i.NomerObsluzhivania == nomerobsluzhivania)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
                throw new Exception("Item no longer available");
            }

            OnObsluzhivanieDeleted(itemToDelete);


            Context.Obsluzhivanies.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterObsluzhivanieDeleted(itemToDelete);

            return itemToDelete;
        }

        public async Task ExportProdazhisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/diplomnyproekt/prodazhis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/diplomnyproekt/prodazhis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProdazhisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/diplomnyproekt/prodazhis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/diplomnyproekt/prodazhis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProdazhisRead(ref IQueryable<TrainsMauiHybrid.Models.Prodazhi> items);

        public async Task<IQueryable<TrainsMauiHybrid.Models.Prodazhi>> GetProdazhis(Query query = null)
        {
            var items = Context.Prodazhis.AsQueryable();

            items = items.Include(i => i.Bilety);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach (var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnProdazhisRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnProdazhiGet(TrainsMauiHybrid.Models.Prodazhi item);
        partial void OnGetProdazhiByNum(ref IQueryable<TrainsMauiHybrid.Models.Prodazhi> items);


        public async Task<TrainsMauiHybrid.Models.Prodazhi> GetProdazhiByNum(long num)
        {
            var items = Context.Prodazhis
                              .AsNoTracking()
                              .Where(i => i.Num == num);

            items = items.Include(i => i.Bilety);

            OnGetProdazhiByNum(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnProdazhiGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnProdazhiCreated(TrainsMauiHybrid.Models.Prodazhi item);
        partial void OnAfterProdazhiCreated(TrainsMauiHybrid.Models.Prodazhi item);

        public async Task<TrainsMauiHybrid.Models.Prodazhi> CreateProdazhi(TrainsMauiHybrid.Models.Prodazhi prodazhi)
        {
            OnProdazhiCreated(prodazhi);

            var existingItem = Context.Prodazhis
                              .Where(i => i.Num == prodazhi.Num)
                              .FirstOrDefault();

            if (existingItem != null)
            {
                throw new Exception("Item already available");
            }

            try
            {
                Context.Prodazhis.Add(prodazhi);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(prodazhi).State = EntityState.Detached;
                throw;
            }

            OnAfterProdazhiCreated(prodazhi);

            return prodazhi;
        }

        public async Task<TrainsMauiHybrid.Models.Prodazhi> CancelProdazhiChanges(TrainsMauiHybrid.Models.Prodazhi item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
                entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
                entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnProdazhiUpdated(TrainsMauiHybrid.Models.Prodazhi item);
        partial void OnAfterProdazhiUpdated(TrainsMauiHybrid.Models.Prodazhi item);

        public async Task<TrainsMauiHybrid.Models.Prodazhi> UpdateProdazhi(long num, TrainsMauiHybrid.Models.Prodazhi prodazhi)
        {
            OnProdazhiUpdated(prodazhi);

            var itemToUpdate = Context.Prodazhis
                              .Where(i => i.Num == prodazhi.Num)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
                throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(prodazhi);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterProdazhiUpdated(prodazhi);

            return prodazhi;
        }

        partial void OnProdazhiDeleted(TrainsMauiHybrid.Models.Prodazhi item);
        partial void OnAfterProdazhiDeleted(TrainsMauiHybrid.Models.Prodazhi item);

        public async Task<TrainsMauiHybrid.Models.Prodazhi> DeleteProdazhi(long num)
        {
            var itemToDelete = Context.Prodazhis
                              .Where(i => i.Num == num)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
                throw new Exception("Item no longer available");
            }

            OnProdazhiDeleted(itemToDelete);


            Context.Prodazhis.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterProdazhiDeleted(itemToDelete);

            return itemToDelete;
        }

        public async Task ExportTrainsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/diplomnyproekt/trains/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/diplomnyproekt/trains/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTrainsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/diplomnyproekt/trains/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/diplomnyproekt/trains/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTrainsRead(ref IQueryable<TrainsMauiHybrid.Models.Train> items);

        public async Task<IQueryable<TrainsMauiHybrid.Models.Train>> GetTrains(Query query = null)
        {
            var items = Context.Trains.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach (var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTrainsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTrainGet(TrainsMauiHybrid.Models.Train item);
        partial void OnGetTrainByNumVagona(ref IQueryable<TrainsMauiHybrid.Models.Train> items);


        public async Task<TrainsMauiHybrid.Models.Train> GetTrainByNumVagona(long numvagona)
        {
            var items = Context.Trains
                              .AsNoTracking()
                              .Where(i => i.NumVagona == numvagona);


            OnGetTrainByNumVagona(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTrainGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTrainCreated(TrainsMauiHybrid.Models.Train item);
        partial void OnAfterTrainCreated(TrainsMauiHybrid.Models.Train item);

        public async Task<TrainsMauiHybrid.Models.Train> CreateTrain(TrainsMauiHybrid.Models.Train train)
        {
            OnTrainCreated(train);

            var existingItem = Context.Trains
                              .Where(i => i.NumVagona == train.NumVagona)
                              .FirstOrDefault();

            if (existingItem != null)
            {
                throw new Exception("Item already available");
            }

            try
            {
                Context.Trains.Add(train);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(train).State = EntityState.Detached;
                throw;
            }

            OnAfterTrainCreated(train);

            return train;
        }

        public async Task<TrainsMauiHybrid.Models.Train> CancelTrainChanges(TrainsMauiHybrid.Models.Train item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
                entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
                entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTrainUpdated(TrainsMauiHybrid.Models.Train item);
        partial void OnAfterTrainUpdated(TrainsMauiHybrid.Models.Train item);

        public async Task<TrainsMauiHybrid.Models.Train> UpdateTrain(long numvagona, TrainsMauiHybrid.Models.Train train)
        {
            OnTrainUpdated(train);

            var itemToUpdate = Context.Trains
                              .Where(i => i.NumVagona == train.NumVagona)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
                throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(train);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTrainUpdated(train);

            return train;
        }

        partial void OnTrainDeleted(TrainsMauiHybrid.Models.Train item);
        partial void OnAfterTrainDeleted(TrainsMauiHybrid.Models.Train item);

        public async Task<TrainsMauiHybrid.Models.Train> DeleteTrain(long numvagona)
        {
            var itemToDelete = Context.Trains
                              .Where(i => i.NumVagona == numvagona)
                              .Include(i => i.Marshutis)
                              .Include(i => i.Obsluzhivanies)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
                throw new Exception("Item no longer available");
            }

            OnTrainDeleted(itemToDelete);


            Context.Trains.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTrainDeleted(itemToDelete);

            return itemToDelete;
        }
    }

}
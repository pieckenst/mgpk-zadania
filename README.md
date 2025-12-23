# MGPK Zadania 📚

Коллекция заданий и проектов по специальности **2-40 01 01 Программное обеспечение информационных технологий** - Могилёвский государственный политехнический колледж

## 🎯 О репозитории

Этот репозиторий содержит решения учебных задач, контрольных работ, лабораторных работ и курсовых проектов, выполненных в рамках обучения в МГПК. Код может служить:

- 📖 **Справочным материалом** для изучения различных технологий
- 🏗️ **Основой для курсовых проектов** 
- 💡 **Примером реализации** типовых задач программирования
- 🤝 **Базой для совместной работы** (pull requests приветствуются!)

## 📄 Лицензия

Проект распространяется под лицензией **Mozilla Public License 2.0**

---

## 🌍 English

Collection of assignments and projects for specialty **2-40 01 01 Information Technology Software** - Mogilev State Polytechnic College

### About this repository

This repository contains solutions for educational tasks, control works, laboratory assignments, and course projects completed during studies at MGPK. The code can serve as:

- 📖 **Reference material** for learning various technologies
- 🏗️ **Foundation for coursework projects**
- 💡 **Implementation examples** for typical programming tasks
- 🤝 **Collaboration base** (pull requests are welcome!)

### License

This project is distributed under the **Mozilla Public License 2.0**


---

## 📋 Содержание проектов

### 🎓 Первый курс

#### 📝 Контрольные работы (Pascal/Delphi)

**📁 kr1** - Контрольная работа №1
- **Технологии:** Pascal/Delphi (Turbo Pascal era)
- **Архитектура:** Процедурное программирование
- **Реализованные задачи:**
  - **Задача 22** (`22.PAS`): Поиск максимальной последовательности положительных чисел
    - Алгоритм: O(n) линейный проход по массиву
    - Использование: статические массивы, простые циклы
    - Ограничения: фиксированный размер массива (100 элементов)
  - **Задача 86** (`86.PAS`): Решение квадратных уравнений
    - Математические вычисления с дискриминантом
    - Процедурная декомпозиция (процедуры `yrav1`, `yrav2`)
    - Кодировка: Windows-1251 (устаревшая)
  - **Задача 104** (`104.PAS`): Сортировка слов по алфавиту
    - Примитивная обработка строк
    - Жестко заданный алфавит (только английский)
    - Отсутствие Unicode поддержки

**🔍 Технический анализ:**
- ✅ **Плюсы:** Простота, понятность алгоритмов
- ❌ **Недостатки:** 
  - Отсутствие обработки ошибок
  - Фиксированные размеры структур данных
  - Устаревшие практики кодирования
  - Нет модульности и переиспользования кода

**📁 kr2** - Контрольная работа №2  
- **Технологии:** Pascal/Delphi
- **Содержание:** Продвинутые алгоритмы и файловые операции
- **Фокус:** Работа с файлами, записями, более сложные структуры данных
- **Эволюция:** Переход к более структурированному программированию

#### 🧪 Лабораторные работы

**📁 lab** - Лабораторные работы первого курса
- **Технологии:** Pascal/Delphi (Object Pascal)
- **Содержание:** Пошаговое изучение основ программирования
- **Методология:** Традиционный подход "от простого к сложному"
- **Цель:** Освоение базовых концепций и синтаксиса языка

**🔍 Педагогический подход:**
- Последовательное изучение конструкций языка
- Акцент на алгоритмическое мышление
- Минимальное использование современных практик разработки

#### 🏗️ Курсовой проект

**📁 kursovaya/aeroport** - Система управления аэропортом
- **Технологии:** Delphi 7/XE (VCL Framework)
- **Архитектура:** Монолитное desktop приложение
- **База данных:** Paradox/dBase (встроенные БД Delphi)
- **Функционал:** 
  - Управление рейсами (CRUD операции)
  - Регистрация пассажиров
  - Мониторинг состояния самолетов
  - Простая отчетность

**🔍 Технический анализ:**
- ✅ **Плюсы:** 
  - Полнофункциональное GUI приложение
  - Интеграция с базой данных
  - Понятная архитектура для начинающих
- ❌ **Недостатки:**
  - Устаревший UI/UX дизайн
  - Отсутствие современных паттернов (MVC/MVP/MVVM)
  - Нет разделения логики и представления
  - Ограниченная масштабируемость

### 🎓 Второй курс

#### 🐍 Python разработка

**📁 python-kr1** - Контрольная работа по Инструментальному ПО
- **Технологии:** Python 3.x
- **Парадигма:** Объектно-ориентированное + функциональное программирование
- **Содержание:** Изучение современных инструментов разработки
- **Задачи:**
  - Работа с библиотеками Python (NumPy, Pandas, Matplotlib)
  - Автоматизация задач (скрипты, парсинг данных)
  - Обработка данных и анализ
  - Введение в веб-разработку (Flask/Django basics)

**🔍 Эволюция навыков:**
- Переход от процедурного к объектно-ориентированному программированию
- Изучение современного синтаксиса и идиом Python
- Работа с пакетным менеджером (pip)
- Введение в концепции DevOps (виртуальные окружения)

#### 💻 C# программирование

**📁 с#-kr1** - Контрольная работа по Конструированию программ
- **Технологии:** C# (.NET Framework 4.x)
- **Архитектура:** Объектно-ориентированное программирование
- **Содержание:** Фундаментальные принципы ООП
- **Задачи:**
  - Создание классов и объектов
  - Наследование и полиморфизм
  - Работа с коллекциями (List<T>, Dictionary<K,V>)
  - Обработка исключений
  - Работа с файловой системой

**📁 с#-kr2** - Контрольная работа №2 по C#
- **Технологии:** C# (.NET Framework)
- **Содержание:** Продвинутые возможности C#
- **Задачи:** 
  - Делегаты и события
  - LINQ запросы
  - Generics (обобщения)
  - Рефлексия (базовый уровень)
  - Многопоточность (Thread, Task)

**🔍 Технический прогресс:**
- ✅ **Улучшения:** 
  - Современная IDE (Visual Studio)
  - Строгая типизация
  - Богатая стандартная библиотека .NET
  - IntelliSense и отладка
- ⚠️ **Ограничения:**
  - Все еще консольные приложения
  - Минимальное использование современных паттернов
  - Отсутствие unit-тестирования

### 🎓 Второй и четвертый курс

#### 🚌 Курсовой проект - Автопарк автобусов

**📁 kursovaya/avtoparkavtobusov** - Система управления автопарком

**🏗️ Структура проекта (Multi-Project Solution):**

**1. KursovayaAvtoparkAvtobusov** - Оригинальная версия (2 курс)
- **Технологии:** C# (.NET 5.0), WPF
- **Архитектура:** Code-behind с элементами MVVM
- **Ключевые библиотеки:**
  - `ModernWpfUI 0.9.6` - Modern UI стили для WPF
  - `Fluent.Ribbon 10.0.4` - Ribbon интерфейс (как в MS Office)
  - `EntityFramework 6.4.4` - **НЕ ИСПОЛЬЗУЕТСЯ** (подтянута как зависимость других библиотек)
  - `ReactiveUI.WPF 17.1` - реактивное программирование
  - `FastReport.OpenSource 2022.1` - генерация отчетов
  - `PostSharp 6.10` - AOP для логирования и диагностики
- **База данных:** Прямые SQL запросы к MS SQL Server (без ORM)
- **Компоненты:**
  - `MainWindow.xaml` - главное окно с Ribbon меню
  - `EmpRecord.xaml` - управление записями сотрудников
  - `TexObslugWindow.xaml` - техническое обслуживание
  - `ReportExport.xaml` - экспорт отчетов
  - `Model1.edmx` - **НЕ ИСПОЛЬЗУЕТСЯ** (артефакт Visual Studio)
  - `LogForm.xaml` - форма авторизации

**2. FluentKursovayaAvtoparkA** - Модернизированная версия (4 курс)
- **Технологии:** C# (.NET 6.0), WPF, WPF-UI 3.0 (Fluent Design)
- **Архитектура:** MVVM с Dependency Injection
- **Ключевые библиотеки:**
  - `WPF-UI 3.0` - современный Fluent Design UI (Windows 11 стиль)
  - `CommunityToolkit.Mvvm 8.0` - MVVM инфраструктура
  - `Microsoft.Extensions.Hosting 6.0` - DI контейнер
  - `FastReport.OpenSource 2023.2` - генерация отчетов PDF
  - `Microsoft.Toolkit.Uwp.Notifications` - Toast уведомления
- **База данных:** Прямые SQL запросы к MS SQL Server
- **Компоненты:**
  - `ViewModels/` - DashboardViewModel, DataViewModel, TicketPageViewModel, MaintenancePageViewModel, SettingsViewModel
  - `Views/Pages/` - DashboardPage, DataPage, SettingsPage, TicketPage, MaintenancePage
  - `Services/` - ApplicationHostService, PageService
  - `Controls/` - кастомные диалоги (SQL connection settings)

**3. Вспомогательные проекты:**
- `SQLServerLogin/` - библиотека подключения к SQL Server
  - Material Design UI (MaterialSkinManager)
  - Сохранение учетных данных с шифрованием (DPAPI)
  - Поддержка Windows и SQL Server аутентификации
- `WpfMessageBoxEx/` - расширенные диалоговые окна
- `WpfReporter/` - система отчетности (Avalonia UI)

**🚀 Функционал:**
- 🚌 **Учет автобусов:** Регистрация, характеристики, статус
- 👥 **Управление персоналом:** Водители, механики, диспетчеры
- 🔧 **Техническое обслуживание:** Планирование ТО, история ремонтов
- 📊 **Dashboard:** Статистика парка в реальном времени
- 📄 **Отчетность:** Генерация PDF через FastReport
- 🔐 **Авторизация:** SQL Server аутентификация с шифрованием паролей
- 🎨 **Темы:** Поддержка светлой/темной темы (Windows 10/11)

**🔍 Эволюция проекта (2 курс → 4 курс):**
| Аспект | Версия 2 курса | Версия 4 курса |
|--------|----------------|----------------|
| **Framework** | .NET 5.0 | .NET 6.0 |
| **UI Library** | ModernWpfUI + Fluent.Ribbon | WPF-UI 3.0 (Fluent Design) |
| **Архитектура** | Code-behind + ReactiveUI | MVVM + DI |
| **База данных** | Прямые SQL запросы | Прямые SQL запросы |
| **Отчеты** | FastReport 2022 | FastReport 2023 |
| **Логирование** | PostSharp AOP | Нет |
| **Навигация** | Ribbon меню | NavigationView (боковая панель) |

**🎓 Сравнение с университетским проектом (БРУ):**
| Аспект | МГПК (Колледж) | БРУ (Университет) |
|--------|----------------|-------------------|
| **Масштаб** | Учебная система | Корпоративная ERP (72,180+ записей) |
| **Технологии** | WPF, прямые SQL | Avalonia, .NET MAUI, Rust+Slint |
| **Архитектура** | Монолит | Микросервисы + REST API |
| **База данных** | MS SQL Server | Entity Framework Core + миграции |
| **Платформы** | Windows only | Cross-platform (Windows, Linux, Android, iOS) |
| **UI Frameworks** | 2 (WPF старый + новый) | 4 (WinForms, Avalonia, MAUI, Rust+Slint) |
| **Производительность** | Локальная БД | 145 API запросов, кэширование 20MB |
| **Тестирование** | Нет | Unit + Integration тесты |
| **Документация** | Минимальная | Полная техническая документация |

**⚠️ Известные ограничения колледжского проекта:**
- Нет REST API (прямое подключение к БД)
- Entity Framework подключен, но не используется (артефакт зависимостей)
- Нет unit-тестов
- Ограниченная масштабируемость
- Windows-only решение
- Смешанные namespace'ы между версиями

**💡 Образовательная ценность:**
Проект демонстрирует эволюцию навыков от колледжского уровня (базовые WPF приложения) к университетскому (корпоративные системы с современными технологиями). Сравнение показывает разницу между учебными проектами и промышленными решениями.

### 🎓 Четвертый курс

#### 🚂 Дипломная работа - Железнодорожные маршруты

**📁 kursovaya/diplomnyproekttrains** - "Построение железнодорожных маршрутов"

**🏗️ Структура проекта (Multi-Project Solution):**

**1. FluentDiplomTrains** - WPF Desktop приложение
- **Технологии:** C# (.NET 6.0), WPF, WPF-UI 3.0 (Fluent Design)
- **Архитектура:** MVVM с Dependency Injection
- **Ключевые библиотеки:**
  - `WPF-UI 3.0` - современный Fluent Design UI
  - `CommunityToolkit.Mvvm 8.0` - MVVM инфраструктура
  - `Microsoft.Extensions.Hosting` - DI контейнер
  - `FastReport.OpenSource` - генерация отчетов PDF
  - `System.Data.SqlClient` - работа с MS SQL Server
  - `Microsoft.Toolkit.Uwp.Notifications` - Windows Toast уведомления
- **Компоненты:**
  - `ViewModels/` - DashboardViewModel, DataViewModel, TicketPageViewModel, MaintenancePageViewModel
  - `Views/Pages/` - страницы приложения (Dashboard, Data, Settings, Ticket, Maintenance)
  - `Services/` - ApplicationHostService, PageService, ReportSystem
  - `Models/` - бизнес-модели (Person, Product, NavigationCard)
  - `Helpers/` - конвертеры (EnumToBoolean, ThemeToIndex, NullToVisibility)

**2. TrainsMauiHybrid** - Cross-platform мобильное приложение
- **Технологии:** .NET 8.0 MAUI Blazor Hybrid
- **Целевые платформы:** Android, iOS, macOS, Windows
- **Ключевые библиотеки:**
  - `Microsoft.AspNetCore.Components.WebView.Maui` - Blazor в MAUI
  - `Masa.Blazor 1.4.0` - Material Design компоненты
  - `Radzen.Blazor 4.25` - UI компоненты для Blazor
  - `DevExpress.Maui.Editors` - продвинутые редакторы
  - `Entity Framework Core 8.0` - ORM для работы с БД
  - `Microsoft.AspNetCore.Identity.EntityFrameworkCore` - аутентификация
  - `CommunityToolkit.Maui` - MAUI расширения
- **Компоненты:**
  - `Components/Pages/` - Blazor страницы
  - `Data/` - DbContext (DiplomnyProektContext, ApplicationIdentityDbContext)
  - `Services/` - SecurityService, ThemeService, DiplomnyProektService
  - `Views/PlatformSpecific/` - платформо-специфичные UI (Android/iOS, Desktop)
  - `Models/DiplomnyProekt/` - доменные модели

**3. Вспомогательные проекты:**
- `SQLServerLogin/` - библиотека авторизации SQL Server
- `WpfMessageBoxEx/` - кастомные диалоговые окна
- `WpfReporter/` - система отчетности
- `DataBaseConnectors/` - коннекторы к БД
- `RazorClassLibrary1/` - общие Razor компоненты

**🚀 Функционал:**
- 🎫 **Управление билетами:** Продажа, возврат, история операций
- 🔧 **Техническое обслуживание:** Учет ремонтов и ТО подвижного состава
- 📊 **Dashboard:** Статистика и аналитика в реальном времени
- 📱 **Cross-platform:** Единая кодовая база для Desktop и Mobile
- 🎨 **Modern UI:** Fluent Design (WPF) + Material Design (MAUI)
- 📄 **Отчетность:** Генерация PDF отчетов через FastReport
- 🔐 **Аутентификация:** ASP.NET Identity с Entity Framework

**🔍 Сравнение с ранними работами колледжа:**
| Аспект | Ранние работы (МГПК) | Дипломная работа |
|--------|---------------------|------------------|
| **Архитектура** | Монолит, code-behind | MVVM + DI + Services |
| **UI Framework** | VCL/WinForms | WPF Fluent + MAUI Blazor |
| **База данных** | Paradox/Access | MS SQL Server + EF Core |
| **Платформы** | Windows only | Windows, Android, iOS, macOS |
| **Отчетность** | Нет/простая | FastReport PDF |
| **Паттерны** | Отсутствуют | MVVM, Repository, DI |
| **Уведомления** | Нет | Windows Toast Notifications |

**⚠️ Известные ограничения:**
- Нет полноценного REST API backend (прямое подключение к БД)
- Отсутствует CI/CD pipeline
- Нет unit-тестов
- Смешивание namespace'ов (FluentKursovayaAvtoparkA в коде)

#### 🌐 Веб-разработка

**📁 htmlkr1** - Контрольная работа по веб-технологиям
- **Технологии:** HTML4/XHTML, PHP 5.x, JavaScript (ES5), SQLite/MySQL
- **Архитектура:** Традиционная серверная разработка (без фреймворков)
- **Реализованные компоненты:**
  - **zadanie1.html:** Статическая HTML страница с таблицей размеров обуви
    - Inline CSS стили
    - Простая табличная верстка
    - Отсутствие адаптивности
  - **select_user.php:** PHP скрипт для работы с БД
    - Прямые SQL запросы (без ORM)
    - Отсутствие защиты от SQL-инъекций
    - Смешивание логики и представления
    - Устаревшая кодировка (windows-1251)

**🔍 Технический анализ веб-проектов:**
- ✅ **Базовые навыки:**
  - Понимание HTTP протокола
  - Работа с формами и базами данных
  - Серверное программирование на PHP
- ❌ **Критические недостатки:**
  - **Безопасность:** SQL-инъекции, XSS уязвимости
  - **Архитектура:** Спагетти-код, нет разделения ответственности
  - **UX/UI:** Устаревший дизайн, отсутствие адаптивности
  - **Производительность:** Неоптимизированные запросы к БД
  - **Современность:** Отсутствие AJAX, REST API, современных фреймворков

**📁 kr2-html** - Продвинутая веб-разработка
- **Технологии:** HTML5, CSS3, JavaScript ES6+, PHP 7+
- **Содержание:** Введение в современные веб-технологии
- **Улучшения:** 
  - Семантическая разметка HTML5
  - CSS Grid/Flexbox для layout
  - Асинхронный JavaScript (Promises, Fetch API)
  - Подготовленные запросы в PHP (PDO)

### 📚 Дополнительные предметы

**📁 Secondary Subjects** - Контрольные работы по общеобразовательным дисциплинам
- **Предметы:**
  - 🛡️ Охрана труда
  - 📐 Высшая математика  
  - 📊 Теория вероятности
  - 🔧 Технология разработки ПО

**📁 secondyearworks** - Дополнительные работы второго курса
- **Содержание:** Различные проекты и задания второго года обучения

**📁 Экзамены-Опусы** - Экзаменационные работы
- **Содержание:** Материалы для подготовки к экзаменам и итоговые работы
---

## 📋 Table of Contents (English)

### 🎓 First Year

#### 📝 Control Works (Pascal/Delphi)

**📁 kr1** - Control Work #1
- **Technologies:** Pascal/Delphi
- **Content:** Basic algorithms and data structures
- **Tasks:**
  - Array and loop operations
  - Quadratic equation solving
  - String and set processing
  - Maximum sequence finding

**📁 kr2** - Control Work #2
- **Technologies:** Pascal/Delphi
- **Content:** Advanced algorithms and file operations
- **Tasks:** More complex data structures and algorithms

#### 🧪 Laboratory Works

**📁 lab** - First year laboratory assignments
- **Technologies:** Pascal/Delphi
- **Content:** Step-by-step programming fundamentals
- **Goal:** Mastering basic concepts and language syntax

#### 🏗️ Course Project

**📁 kursovaya/aeroport** - Airport Management System
- **Technologies:** Delphi
- **Description:** Automated system for airport operations management
- **Features:**
  - Flight management
  - Passenger registration
  - Aircraft status monitoring
  - Reporting and statistics

### 🎓 Second Year

#### 🐍 Python Development

**📁 python-kr1** - Software Development Control Work
- **Technologies:** Python
- **Content:** Modern development tools study
- **Tasks:**
  - Working with Python libraries
  - Task automation
  - Data processing

#### 💻 C# Programming

**📁 с#-kr1** - Program Design Control Work
- **Technologies:** C#
- **Content:** Object-oriented programming
- **Tasks:**
  - Class and object creation
  - Inheritance and polymorphism
  - Collection handling

**📁 с#-kr2** - C# Control Work #2
- **Technologies:** C#
- **Content:** Advanced C# features
- **Tasks:** Complex patterns and architectural solutions

### 🎓 Second and Fourth Year

#### 🚌 Course Project - Bus Fleet Management

**📁 kursovaya/avtoparkavtobusov** - Bus Fleet Management System

**🏗️ Project Structure (Multi-Project Solution):**

**1. KursovayaAvtoparkAvtobusov** - Original Version (2nd year)
- **Technologies:** C# (.NET 5.0), WPF
- **Architecture:** Code-behind with MVVM elements
- **Key Libraries:** ModernWpfUI, Fluent.Ribbon, EntityFramework 6, ReactiveUI, FastReport, PostSharp

**2. FluentKursovayaAvtoparkA** - Modernized Version (4th year)
- **Technologies:** C# (.NET 6.0), WPF, WPF-UI 3.0 (Fluent Design)
- **Architecture:** MVVM with Dependency Injection
- **Key Libraries:** WPF-UI 3.0, CommunityToolkit.Mvvm 8.0, FastReport 2023, MS SQL Server

**3. Helper Projects:**
- `SQLServerLogin/` - SQL Server connection library with Material Design UI
- `WpfMessageBoxEx/` - Extended dialog boxes
- `WpfReporter/` - Reporting system (Avalonia UI)

**🚀 Features:**
- 🚌 Bus inventory and registration
- 👥 Personnel management (drivers, mechanics)
- 🔧 Maintenance scheduling and history
- 📊 Real-time dashboard statistics
- 📄 PDF report generation via FastReport
- 🔐 SQL Server authentication with encrypted credentials
- 🎨 Light/Dark theme support (Windows 10/11)

**⚠️ Known Limitations:**
- No REST API (direct DB connection)
- No Entity Framework Core in new version
- Missing unit tests

### 🎓 Fourth Year

#### 🚂 Diploma Work - Railway Routes

**📁 kursovaya/diplomnyproekttrains** - "Railway Route Construction System"

**🏗️ Project Structure (Multi-Project Solution):**

**1. FluentDiplomTrains** - WPF Desktop Application
- **Technologies:** C# (.NET 6.0), WPF, WPF-UI 3.0 (Fluent Design)
- **Architecture:** MVVM with Dependency Injection
- **Key Libraries:** WPF-UI 3.0, CommunityToolkit.Mvvm 8.0, FastReport.OpenSource, MS SQL Server

**2. TrainsMauiHybrid** - Cross-platform Mobile Application
- **Technologies:** .NET 8.0 MAUI Blazor Hybrid
- **Target Platforms:** Android, iOS, macOS, Windows
- **Key Libraries:** Masa.Blazor, Radzen.Blazor, DevExpress.Maui, Entity Framework Core 8.0

**🚀 Features:**
- 🎫 Ticket management (sales, returns, history)
- 🔧 Maintenance tracking for rolling stock
- 📊 Real-time dashboard with analytics
- 📱 Cross-platform: single codebase for Desktop and Mobile
- 🎨 Modern UI: Fluent Design (WPF) + Material Design (MAUI)
- 📄 PDF report generation via FastReport
- 🔐 ASP.NET Identity authentication

**⚠️ Known Limitations:**
- No dedicated REST API backend (direct DB connection)
- No CI/CD pipeline
- Missing unit tests

#### 🌐 Web Development

**📁 htmlkr1** - Web Technologies Control Work
- **Technologies:** HTML, PHP, JavaScript, SQLite
- **Content:** Internet application development
- **Tasks:**
  - Database operations
  - Server-side PHP programming
  - Interactive web forms

**📁 kr2-html** - Advanced Web Development
- **Technologies:** HTML5, CSS3, JavaScript, PHP
- **Content:** Modern web technologies and frameworks

### 📚 Additional Subjects

**📁 Secondary Subjects** - Control works for general education disciplines
- **Subjects:**
  - 🛡️ Labor protection
  - 📐 Higher mathematics
  - 📊 Probability theory
  - 🔧 Software development technology

**📁 secondyearworks** - Additional second-year assignments
- **Content:** Various projects and tasks from the second year of study

**📁 Экзамены-Опусы** - Examination works
- **Content:** Exam preparation materials and final works

---

## 🚀 Getting Started

### Prerequisites

Depending on the project you want to explore, you'll need:

- **Pascal/Delphi projects:** Delphi IDE or Free Pascal
- **C# projects:** Visual Studio or .NET SDK
- **Python projects:** Python 3.x
- **Web projects:** Web server (Apache/Nginx) with PHP support
- **Database projects:** MS SQL Server, SQLite

### Installation & Usage

1. **Clone the repository:**
   ```bash
   git clone https://github.com/yourusername/mgpk-zadania.git
   cd mgpk-zadania
   ```

2. **Navigate to the desired project folder**
3. **Follow the specific instructions in each project's documentation**

## 🤝 Contributing

Contributions are welcome! Please feel free to:

- 🐛 Report bugs
- 💡 Suggest improvements
- 🔧 Submit pull requests
- 📖 Improve documentation

### How to Contribute

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📞 Contact

For questions about specific projects or collaboration opportunities, please open an issue in this repository.

## 🎓 Educational Context

This repository represents the academic journey through the Information Technology Software specialty at Mogilev State Polytechnic College, showcasing the progression from basic programming concepts to complex enterprise-level applications.

**Learning Path:**
- **Year 1:** Fundamentals (Pascal/Delphi)
- **Year 2:** Modern languages (Python, C#)
- **Year 3-4:** Enterprise development (WPF, .NET MAUI, Blazor)

 

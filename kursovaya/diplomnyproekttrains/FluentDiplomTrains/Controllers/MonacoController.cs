

using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;

using Wpf.Ui.Appearance;
using FluentKursovayaAvtoparkA.Models.Monaco;

namespace FluentKursovayaAvtoparkA.Controllers;

/*
public class MonacoController
{
    private const string EditorContainerSelector = "#root";

    private const string EditorObject = "wpfUiMonacoEditor";

    private volatile WebView2 _webView;

    public MonacoController(WebView2 webView)
    {
        _webView = webView;
    }

    public async Task CreateAsync()
    {
        await _webView.ExecuteScriptAsync(
            $$"""
            const {{EditorObject}} = monaco.editor.create(document.querySelector('{{EditorContainerSelector}}'));
            window.onresize = () => {{{EditorObject}}.layout();}
            """
        );
    }

    public async Task SetThemeAsync(ApplicationTheme appApplicationTheme)
    {
        const string uiThemeName = "wpf-ui-app-theme";
        var baseMonacoTheme = appApplicationTheme == ApplicationTheme.Light ? "vs" : "vs-dark";

        // TODO: Parse theme from object

        await _webView.ExecuteScriptAsync(
            $$$"""
            monaco.editor.defineTheme('{{{uiThemeName}}}', {
                base: '{{{baseMonacoTheme}}}',
                inherit: true,
                rules: [{ background: 'FFFFFF00' }],
                colors: {'editor.background': '#FFFFFF00','minimap.background': '#FFFFFF00',}});
            monaco.editor.setTheme('{{{uiThemeName}}}');
            """
        );
    }

    public async Task SetLanguageAsync(MonacoLanguage monacoLanguage)
    {
        var languageId =
            monacoLanguage == MonacoLanguage.ObjectiveC ? "objective-c" : monacoLanguage.ToString().ToLower();

        await _webView.ExecuteScriptAsync(
            "monaco.editor.setModelLanguage(" + EditorObject + $".getModel(), \"{languageId}\");"
        );
    }

    public async Task SetContentAsync(string contents)
    {
        var literalContents = SymbolDisplay.FormatLiteral(contents, false);

        await _webView.ExecuteScriptAsync(EditorObject + $".setValue(\"{literalContents}\");");
    }

    public void DispatchScript(string script)
    {
        if (_webView == null)
            return;

        Application.Current.Dispatcher.InvokeAsync(async () => await _webView!.ExecuteScriptAsync(script));
    }
}
*/

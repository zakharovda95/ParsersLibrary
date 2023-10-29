using AngleSharp;
using AngleSharp.Dom;

namespace ParsersLibrary.Classes;

public abstract class ParserAngle
{
    protected async Task<IDocument?> GetDocument(string url)
    {
        try
        {
            var configuration = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(configuration);
            var document = await context.OpenAsync(url);
            return document;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    
    protected static List<IElement> GetCardNodes(IDocument document, string selector) {
        var carCards = document.QuerySelectorAll(selector);
        return carCards.ToList();
    }
    
    protected static string? GetAttribute(IElement card, string selector, string attribute)
    {
        var elem = card.QuerySelector(selector);
        return elem?.GetAttribute(attribute)?.Trim();
    }

    protected static string? GetTextContent(IElement card, string selector)
    {
        var elem = card.QuerySelector(selector);
        return elem?.TextContent?.Trim();
    }

    public abstract Task<List<T>> ParseData<T>(string uri, string path, string query);
}
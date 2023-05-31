using Markdig;
using Markdig.Renderers;
using Markdig.Renderers.Html;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;

namespace GJM.Helpers
{
    public class CustomMarkdownExtension : IMarkdownExtension
    {
        public void Setup(MarkdownPipelineBuilder pipeline)
        {
            pipeline.DocumentProcessed += DocumentProcessed;
        }

        private void DocumentProcessed(MarkdownDocument document)
        {
            foreach (var node in document.Descendants())
            {
                if (node is LinkInline linkInline && linkInline.IsImage)
                {
                    linkInline.GetAttributes().AddClass("img-responsive");
                }
            }
        }

        public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
        {
            // Nothing to do here
        }
    }

    public static class MarkdownPipelineBuilderExtensions
    {
        public static MarkdownPipelineBuilder UseCustomMarkdownExtension(this MarkdownPipelineBuilder pipeline)
        {
            pipeline.Extensions.Add(new CustomMarkdownExtension());
            return pipeline;
        }
    }

}

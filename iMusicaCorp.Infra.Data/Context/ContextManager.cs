using iMusicaCorp.Infra.Data.Interface;
using System.Web;

namespace iMusicaCorp.Infra.Data.Context
{
    public class ContextManager: IContextManager
    {
        private const string ContextKey = "ContextManager.Context";
        public MusicaCorpContext GetContext()
        {
            if (HttpContext.Current.Items[ContextKey] == null)
            {
                HttpContext.Current.Items[ContextKey]= new MusicaCorpContext();
            }

            return (MusicaCorpContext) HttpContext.Current.Items[ContextKey];

        }
    }
}

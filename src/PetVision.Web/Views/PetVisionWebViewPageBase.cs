using Abp.Web.Mvc.Views;

namespace PetVision.Web.Views
{
    public abstract class PetVisionWebViewPageBase : PetVisionWebViewPageBase<dynamic>
    {

    }

    public abstract class PetVisionWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected PetVisionWebViewPageBase()
        {
            LocalizationSourceName = PetVisionConsts.LocalizationSourceName;
        }
    }
}
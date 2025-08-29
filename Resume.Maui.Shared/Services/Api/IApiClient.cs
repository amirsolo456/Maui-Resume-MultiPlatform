using Resume.Maui.Shared.Core;
using Resume.Maui.Shared.Core.Entities.MenuItems;

namespace Resume.Maui.Shared.Services.Api;

public interface IApiClient
{
    Task<Response> SendRequestAsync<Response, Request>(Request request)
        where Response : BaseResponse<ResponseData>
        where Request : BaseRequest<Request>;
}

public class ApiClient : IApiClient
{
    public ApiClient()
    {
        // میتونی HttpClient یا سایر تنظیمات رو اینجا اضافه کنی
    }

    public async Task<Response> SendRequestAsync<Response, Request>(Request request)
        where Response : BaseResponse<ResponseData>
        where Request : BaseRequest<Request>
    {
        // اینجا logic ارسال به API و دریافت Response
        throw new NotImplementedException();
    }
}

using Resume.Maui.Shared.Core;
using Resume.Maui.Shared.Core.Entities.MenuItems;

namespace Resume.Maui.Shared.Services.Api;

public interface INavigationItemsService<Response, Request>
        where Response : BaseResponse<ResponseData>
        where Request : BaseRequest<Request>, new()
{
    Task<Response> GetNavItemsAsync(int PersonID);
    Task<int> GetItemsCountAsync();
}

public class NavigationItemsService<Response, Request> : INavigationItemsService<Response, Request>
    where Response : BaseResponse<ResponseData>
    where Request : BaseRequest<Request>, new()
{
    private readonly IApiClient _apiClient;

    public NavigationItemsService(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<Response> GetNavItemsAsync(int PersonID)
    {
        var request = new Request();
        // اگر Requestت فیلد PersonID دارد، باید در BaseRequest یا کلاس مشتق اضافه شود
        // برای مثال اگر BaseRequest<int> باشد یا Property اضافه شود:
        // request.PersonID = PersonID;

        return await _apiClient.SendRequestAsync<Response, Request>(request);
    }

    public Task<int> GetItemsCountAsync()
    {
        throw new NotImplementedException();
    }
}

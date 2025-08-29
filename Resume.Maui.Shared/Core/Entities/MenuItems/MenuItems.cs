using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Resume.Maui.Shared.Core.Entities.MenuItems;

public class Request : BaseRequest<Request>
{
    public int PersonID { get; set; }
}

public class Response : BaseResponse<ResponseData>
{
    public int PersonId { get; set; }
}

public class ResponseData
{
    public int ID { get; set; }
    public string DisplayName { get; set; }
    public string NavUrl { get; set; }
    public string Icon { get; set; }
}


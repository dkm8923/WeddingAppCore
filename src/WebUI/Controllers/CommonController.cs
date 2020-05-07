using CleanArchitecture.Application.UiAppSettingApplications.Queries;
using CleanArchitecture.Application.UiAppSettingReferenceTypes.Queries;
using CleanArchitecture.Application.UiAppSettings.Queries;
using CleanArchitecture.Application.UiAppSettings.UiAppSettingApplications.Queries;
using CleanArchitecture.Application.UiAppSettings.UiAppSettingFooters.Queries;
using CleanArchitecture.Application.UsaStates.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers
{
    public class CommonController : ApiController
    {
        //public enum ReferenceTypes
        //{
        //    NavLink,
        //    NavLinkSection,
        //    NavLinkUserProfile,
        //    NavLinkHome,
        //    HeaderBaseModel,
        //    FooterBaseModel
        //}

        [HttpPost]
        public async Task<ActionResult<GetCommonDataResponse>> GetCommonData(GetCommonDataRequest command)
        {
            command.UiLayoutData = new UiLayoutDataReq { ApplicationId = 5 };
            
            var ret = new GetCommonDataResponse();
            var refTypes = await Mediator.Send(new GetUiAppSettingReferenceTypeQuery());

            if (command.UsaStates)
            {
                ret.UsaStates = await Mediator.Send(new GetUsaStateQuery());
            }

            if (command.UiAppSettingReferenceTypes)
            {
                ret.UiAppSettingReferenceTypes = refTypes;
            }

            if (command.UiAppSettingApplications)
            {
                ret.UiAppSettingApplications = await Mediator.Send(new GetUiAppSettingApplicationQuery());
            }

            if (command.UiAppSettingFooters)
            {
                ret.UiAppSettingFooters = await Mediator.Send(new GetUiAppSettingFooterQuery());
            }

            if (command.UiAppSettings)
            {
                ret.UiAppSettings = await Mediator.Send(new GetUiAppSettingQuery());
            }

            if (command.UiLayoutData != null)
            {
                ret.LayoutData = new LayoutData();

                var footer = await Mediator.Send(new GetUiAppSettingFooterQuery { ApplicationId = command.UiLayoutData.ApplicationId });
                if (footer.Count() > 0) 
                {
                    ret.LayoutData.Footer = new UiAppSettingFooterDto();
                    ret.LayoutData.Footer = footer.FirstOrDefault();
                }

                //var header = await Mediator.Send(new GetUiAppSettingFooterQuery { ApplicationId = command.UiLayoutData.ApplicationId });
                //if (header.Count() > 0)
                //{
                //    ret.LayoutData.Header = new UiAppSettingHeaderDto();
                //    ret.LayoutData.Header = Header.FirstOrDefault();
                //}
            }

            return ret;
        }
    }
}

public class GetCommonDataRequest
{
    public bool UsaStates { get; set; }
    public bool UiAppSettingReferenceTypes { get; set; }
    public bool UiAppSettingApplications { get; set; }
    public bool UiAppSettingFooters { get; set; }
    public bool UiAppSettings { get; set; }
    public UiLayoutDataReq UiLayoutData { get; set; }
}

public class UiLayoutDataReq
{
    public long ApplicationId { get; set; }
}

public class GetCommonDataResponse
{
    public IEnumerable<UsaStateDto> UsaStates { get; set; }
    public IEnumerable<UiAppSettingReferenceTypeDto> UiAppSettingReferenceTypes { get; set; }
    public IEnumerable<UiAppSettingApplicationDto> UiAppSettingApplications { get; set; }
    public IEnumerable<UiAppSettingFooterDto> UiAppSettingFooters { get; set; }
    public IEnumerable<UiAppSettingDto> UiAppSettings { get; set; }
    public LayoutData LayoutData { get; set; }
}

public class LayoutData
{
    public UiAppSettingFooterDto Footer { get; set; }
    //public UiAppSettingHeaderDto Header { get; set; }
}

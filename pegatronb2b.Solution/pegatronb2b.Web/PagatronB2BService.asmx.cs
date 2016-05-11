using pegatronb2b.Web.Services;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace pegatronb2b.Web
{
    /// <summary>
    /// Summary description for PagatronB2BService
    /// </summary>
    [WebService(Namespace = "http://pagatronb2b.asmx/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PagatronB2BService : System.Web.Services.WebService
    {
        private readonly IPgaGrService _grService;
        private readonly IUnitOfWorkAsync _unitOfWork;
        public PagatronB2BService(IPgaGrService grService, IUnitOfWorkAsync unitOfWork)
        {
            _grService = grService;
            _unitOfWork = unitOfWork;
        }
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public pegatronb2b.Web.Models.GrReponseViewModel GrInbound(pegatronb2b.Web.Models.GrRequestViewModel request) {

            var response = _grService.B2BInbound(request);
            _unitOfWork.SaveChanges();
            return response;
        
        }
    }
}

using Dice.Bll;
using DiceWebAPI.Filter;
using DiceWebAPI.Models;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DiceWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorization]
    public class MainController : ApiController
    {

        // POST: api/Main
        public BaseResponse Post([FromBody]BaseRequest request)
        {
            try
            {
                return GetResponse(request);

            }
            catch (DiceException ex)
            {

                return new BaseResponse { ResponseCode = ex.Id, ResponseObject = ex.Message };
            }
            catch (Exception ex)
            {
                return new BaseResponse { ResponseObject = ex.Message };
            }

        }
        private BaseResponse GetResponse(BaseRequest request)
        {
            switch (request.Controller)
            {
                case "Player":
                    return new PlayerController().InvokeFunction(request);
                case "Game":
                    return new GameController().InvokeFunction(request);

            }
            throw new Exception();
        }
    }
}

import { Injectable } from "@angular/core";
import { ApiRequestService } from "app/shared/api.request.service";

const Controller = "Player";

@Injectable()
export class PlayerRequestService {

    constructor(private ApiRequestService: ApiRequestService) {
    }


    loginPlayer(data: any) {

        let request = this.prepairRequest(data, "LoginPlayer");

        return this.ApiRequestService.Request(request);
    }
    registrationPlayer(data:any){
        let request = this.prepairRequest(data, "RegistratePlayer");
        return this.ApiRequestService.Request(request);
    }

    private prepairRequest(data: any, method: string) {

        let body = {
            Controller: Controller,
            Method: method,
            RequestObject: data
        };
        return body;
    }
}
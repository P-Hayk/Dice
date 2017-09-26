import { Injectable } from "@angular/core";
import { ApiRequestService } from "app/shared/api.request.service";
import {ControllerName, StatusMethod} from "./status"

const Controller:number = ControllerName.Player;

@Injectable()
export class PlayerRequestService {

    constructor(private ApiRequestService: ApiRequestService) {
    }


    loginPlayer(data: any) {

        let request = this.prepairRequest(data, StatusMethod.LoginPlayer);

        return this.ApiRequestService.Request(request);
    }
    registrationPlayer(data:any){
        let request = this.prepairRequest(data, StatusMethod.RegistratePlayer);
        return this.ApiRequestService.Request(request);
    }

    private prepairRequest(data: any, method: number) {

        let body = {
            Controller: Controller,
            Method: method,
            RequestObject: data
        };
        return body;
    }
}
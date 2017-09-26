import { Injectable } from "@angular/core";
import { ApiRequestService } from "app/shared/api.request.service";
import {ControllerName,StepMethod} from "./status";

const Controller:number = ControllerName.Step;

@Injectable()
export class StepRequestService {

    constructor(private ApiRequestService: ApiRequestService) {
    }


    roleDice(data: any) {

        let request = this.prepairRequest(data, StepMethod.RoleDice);

        return this.ApiRequestService.Request(request);
    }
   

    private prepairRequest(data: any, method: number) {

        let body = {
            Controller: Controller,
            Method: method,
            RequestObject: data,
            //Token:localStorage.getItem('token')
        };
        return body;
    }
}
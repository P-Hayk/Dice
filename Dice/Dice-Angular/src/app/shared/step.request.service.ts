import { Injectable } from "@angular/core";
import { ApiRequestService } from "app/shared/api.request.service";

const Controller = "Step";

@Injectable()
export class StepRequestService {

    constructor(private ApiRequestService: ApiRequestService) {
    }


    roleDice(data: any) {

        let request = this.prepairRequest(data, "RoleDice");

        return this.ApiRequestService.Request(request);
    }
   

    private prepairRequest(data: any, method: string) {

        let body = {
            Controller: Controller,
            Method: method,
            RequestObject: data,
            Token:localStorage.getItem('token')
        };
        return body;
    }
}
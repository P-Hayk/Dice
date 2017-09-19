import { Injectable } from "@angular/core";
import { ApiRequestService } from "app/shared/api.request.service";

const Controller = "Game";

@Injectable()
export class GameRequestService {

    constructor(private ApiRequestService: ApiRequestService) {
    }


    createGame(data: any) {

        let request = this.prepairRequest(data, "CreateGame");

        return this.ApiRequestService.Request(request);
    }

    joinToGame(data: any) {
        
                let request = this.prepairRequest(data, "JoinToGame");
        
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
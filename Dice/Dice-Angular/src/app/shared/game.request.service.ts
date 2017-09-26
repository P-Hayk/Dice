import { Injectable } from "@angular/core";
import { ApiRequestService } from "app/shared/api.request.service";
import {ControllerName,GameMethod} from "./status";

const Controller:number = ControllerName.Game;

@Injectable()
export class GameRequestService {

    constructor(private ApiRequestService: ApiRequestService) {
    }


    createGame(data: any) {

        let request = this.prepairRequest(data, GameMethod.CreateGame);

        return this.ApiRequestService.Request(request);
    }

    joinToGame(data: any) {
        
                let request = this.prepairRequest(data, GameMethod.JoinToGame);
        
                return this.ApiRequestService.Request(request);
            }

    private prepairRequest(data: any, method: number) {

        let body = {
            Controller: Controller,
            Method: method,
            //Token:localStorage.getItem('token'),
            RequestObject: data
        };
        return body;
    }
}
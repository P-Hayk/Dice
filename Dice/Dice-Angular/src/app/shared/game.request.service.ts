import { Injectable } from "@angular/core";
import { ApiRequestService } from "app/shared/api.request.service";
import { ControllerName, GameMethod } from "./status";

const Controller: number = ControllerName.Game;

@Injectable()
export class GameRequestService {

    constructor(private ApiRequestService: ApiRequestService) {
    }


    createGame(data: any) {

        return this.ApiRequestService.Request(data, Controller, GameMethod.CreateGame);
    }

    joinToGame(data: any) {

        return this.ApiRequestService.Request(data,Controller,GameMethod.JoinToGame);
    }

    
}
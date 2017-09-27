import { Injectable } from "@angular/core";
import { ApiRequestService } from "app/shared/api.request.service";
import { ControllerName, StatusMethod } from "./status"

const Controller: number = ControllerName.Player;

@Injectable()
export class PlayerRequestService {

    constructor(
        private ApiRequestService: ApiRequestService
    ) { }


    loginPlayer(data: any) {

        return this.ApiRequestService.Request(data, Controller, StatusMethod.LoginPlayer);
    }

    registrationPlayer(data: any) {

        return this.ApiRequestService.Request(data, Controller, StatusMethod.RegistratePlayer);
    }


}
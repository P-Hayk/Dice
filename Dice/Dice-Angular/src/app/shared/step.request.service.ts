import { Injectable } from "@angular/core";
import { ApiRequestService } from "app/shared/api.request.service";
import { ControllerName, StepMethod } from "./status";

const Controller: number = ControllerName.Step;

@Injectable()
export class StepRequestService {

    constructor(private ApiRequestService: ApiRequestService) {
    }
    roleDice(data: any) {

        return this.ApiRequestService.Request(data, Controller, StepMethod.RoleDice);
    }
}
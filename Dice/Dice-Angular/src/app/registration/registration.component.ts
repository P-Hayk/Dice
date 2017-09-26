import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, Route } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
import { PlayerRequestService } from "app/shared/player.request.service";
import { CookieService } from 'angular2-cookie/core';
import { BaseResponse, InheritResponse } from '../shared/base.response';
import { StatusMethod } from "app/shared/status";


@Component({
    selector: 'registration',
    templateUrl: './registration.component.html'
})

export class RegistrationComponent implements OnInit, OnDestroy {

    constructor(
        private PlayerRequestService: PlayerRequestService,
        private cookieService: CookieService,
        private route: Router) {
    }

    public regUserName: string;
    public regPass: string;
    public regRepeatePass: string;
    public FirstName: string;
    public LastName: string;

    public RegError: boolean = false;

    ngOnDestroy(): void {

    }
    ngOnInit(): void {

    }

    registration() {
        if (this.regPass != this.regRepeatePass) {
            console.log("ERROR Password!=RepeatePassword");
            return;
        }
        let data =
            {
                UserName: this.regUserName,
                PasswordHash: this.regPass,
                FirstName: this.FirstName,
                LastName: this.LastName
            }
        this.cookieService.putObject('form', data);
        this.cookieService.put('method', StatusMethod.RegistratePlayer.toString());

        this.PlayerRequestService.registrationPlayer(data).subscribe(
            result => {
                this.ClearCookie();
                this.RegError = false;
                var response: BaseResponse = result as BaseResponse;
                var responseObject = response.ResponseObject as InheritResponse;

                if (result.ResponseCode == 0) {
                    this.cookieService.putObject('token', responseObject.token);
                    this.cookieService.putObject('playerid', responseObject.playerid);
                    this.route.navigate(['desk']);
                }
                else
                    this.route.navigate(['login']);
                
            }, error => {
                this.ClearCookie();

                this.RegError = true;
                this.SetDefaultForm();
            });
    }
    SetDefaultForm() {
        this.regUserName = null;
        this.regPass = null;
        this.regRepeatePass = null;
        this.FirstName = null;
        this.LastName = null
    }
    ClearCookie() {
        this.cookieService.remove('form');
        this.cookieService.remove('method');
    }
}
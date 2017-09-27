import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, Route } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
import { PlayerRequestService } from "app/shared/player.request.service";
import { CookieService } from 'angular2-cookie/core';
import { BaseResponse, InheritResponse } from '../shared/base.response';
import { StatusMethod } from "app/shared/status";

@Component({
    selector: 'login',
    templateUrl: './login.component.html'
})

export class LoginComponent implements OnInit, OnDestroy {

    constructor(
        private PlayerRequestService: PlayerRequestService,
        private cookieService: CookieService,
        private route: Router
    ) {
    }

    public loginUserName: string;
    public loginPass: string;
    public loginError: boolean = false;

    ngOnDestroy(): void {

    }
    ngOnInit(): void {

    }

    login() {
        let data =
            {
                UserName: this.loginUserName,
                PasswordHash: this.loginPass
            }
        this.cookieService.putObject('form', data);
        this.cookieService.put('method', StatusMethod.LoginPlayer.toString());

        this.PlayerRequestService.loginPlayer(data).subscribe(
            result => {
                console.log("---------------------------");
                console.log(result);
                this.ClearCookie();
                this.loginError = false;
                var response: BaseResponse = result as BaseResponse;
                var responseObject = response.ResponseObject as InheritResponse;

                if (response.ResponseCode == 0) {
                    localStorage.setItem("Id",responseObject.playerid.toString())
                    this.cookieService.putObject('token', responseObject.token);
                    this.cookieService.putObject('playerid', responseObject.playerid);
                    this.route.navigate(['desk']);
                }
                else
                    this.route.navigate(['login']);
                
            }, error => {
                console.log("mtav error");
                this.ClearCookie();

                this.loginError = true;
                this.SetDefaultForm();
            });
    }
    SetDefaultForm() {
        this.loginUserName = null;
        this.loginPass = null;
    }
    ClearCookie() {
        this.cookieService.remove('form');
        this.cookieService.remove('method');
    }
}
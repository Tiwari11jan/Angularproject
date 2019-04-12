import { Component } from '@angular/core';
import { AppComponent } from '../app/app.component';
import { Router } from '@angular/router';



@Component({
    selector: 'login-page',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css'],    

})




export class LoginComponent {
    constructor(private _appComp: AppComponent, private router: Router) {
        this._appComp.hideMainNav = false;
    }

    ngOnInit() {
        sessionStorage.removeItem('user');
    }

    onLogin() {
        debugger;
        sessionStorage.setItem('user', 'admin');
        this.router.navigate(['/home']);
    }
}

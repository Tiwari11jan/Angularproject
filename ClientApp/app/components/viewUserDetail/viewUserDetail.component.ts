import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Http } from '@angular/http';

@Component({
    selector: 'userDetail-page',
    templateUrl: './viewUserDetail.component.html'
})
export class ViewUserDetailComponent {
    UserId: number = 0;
    Name: string = "";
    Email: string = "";
    SeatNo: string = "";
    FloorNo: string = "";
    UserType: string = "";


    result: any;
    constructor(private _http: Http, private _avRoute: ActivatedRoute, @Inject('BASE_URL') private baseUrl: string, private router: Router) {
        if (this._avRoute.snapshot.params["id"]) {
            this.UserId = this._avRoute.snapshot.params["id"];
        }
        this.LoadDataById();
    }

    ngOnInit() {
        if (sessionStorage.length == 0) {
            this.router.navigate(['/login']);
        }
    }


    LoadDataById() {
        this._http.get(this.baseUrl + 'api/Users/' + this.UserId).subscribe(result => {
            this.result = result.json() as any;
            this.Name = this.result.name;
            this.Email = this.result.email;
            this.SeatNo = this.result.seatNo;
            this.FloorNo = this.result.floorNo;
            this.UserType = this.result.userType;
        });
    }

}


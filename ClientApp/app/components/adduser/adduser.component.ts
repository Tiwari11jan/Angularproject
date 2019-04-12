import { Component, ViewChild, ElementRef, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { AppComponent } from '../app/app.component';
import { Router } from '@angular/router';


@Component({
    selector: 'adduser-page',
    templateUrl: './adduser.component.html'
})
export class AddUserComponent {

    //bind floor no list in dropdown
    floorList: floorModal[] = [];

    //bind user type dropdown list
    userTypeList: userTypeModal[] = [];

    //two way binding 
    Modal = new userDetailsModal();

    //to show the whole data
    userList: userDetailsModal[] = [];

    buttonName: string = "Save";
    public id: number = 0;
    errorMessage: string = "";


    constructor(private _http: Http, @Inject('BASE_URL') private baseUrl: string, private _appComp: AppComponent, private router: Router) {
        this.LoadFloorNo();
        this.LoadUserTypes();
        this.LoadData();

        //let key = 'Item1';
        //localStorage.setItem(key, 'Manpreet Singh');
        //sessionStorage.setItem(key, 'Manpreet Sigh');
    }

    ngOnInit() {
        if (sessionStorage.length == 0) {
            this.router.navigate(['/login']);
        }
    }

    LoadFloorNo() {
        this._http.get(this.baseUrl + 'api/Users/GetFloorNo').subscribe(result => {
            this.floorList = result.json() as floorModal[];
        });
    }

    LoadUserTypes() {
        this._http.get(this.baseUrl + 'api/Users/GetUsersTypes').subscribe(result => {
            this.userTypeList = result.json() as userTypeModal[];
        });
    }

    LoadData() {
        this._http.get(this.baseUrl + 'api/Users').subscribe(result => {
            this.userList = result.json() as userDetailsModal[];
        });
    }

    onSave() {
        if (this.checkValidation()) {
            debugger;
            if (this.Modal.userId == 0) {
                this._http.post(this.baseUrl + 'api/Users', this.Modal).subscribe((res) => {
                    this.LoadData();
                    this.onCancel();
                });
            }
            else {
                this._http.put(this.baseUrl + 'api/Users', this.Modal).subscribe(result => {
                    this.LoadData();
                    this.onCancel();
                });
            }
        }
        else {
            this._appComp.popupHeader = "Error Message";
            this._appComp.popupBody = this.errorMessage;
            this._appComp.ShowPopup();
        }
    }

    onEdit(id: number) {
    
        this.buttonName = "Update";
        this._http.get(this.baseUrl + 'api/Users/' + id).subscribe(result => {
            this.Modal = result.json() as userDetailsModal;
        });
    }


    setDeleteId(id: number) {
        this.id = id;
    }

    onDelete() {
        this._http.delete(this.baseUrl + 'api/Users/' + this.id).subscribe((res) => {
            this.LoadData();
        });
    }

    checkValidation(): boolean {
        this.errorMessage = "";
        if (this.Modal.name == "") {
            this.errorMessage = " * Please enter name" + "<br />";
        }

        if (this.Modal.email == "") {
            this.errorMessage += " * Please enter email" + "<br />";
        }
        if (this.Modal.seatNo == "") {
            this.errorMessage += " * Please enter seat number" + "<br />";
        }
        if (this.Modal.floorId == 0) {
            this.errorMessage += " * Please select floor" + "<br />";
        }

        if (this.Modal.userTypeId == 0) {
            this.errorMessage += " * Please select user type" + "<br />";
        }
        if (this.errorMessage == "") {
            return true;
        }
        else {
            return false;
        }
    }

    onCancel() {
        this.Modal.userId = 0;
        this.Modal.name = "";
        this.Modal.email = "";
        this.Modal.seatNo = "";
        this.Modal.floorId = 0;
        this.Modal.floorNo = "";
        this.Modal.userTypeId = 0;
        this.Modal.userType = "";
        this.buttonName = "Save";
    }
}


class userTypeModal {
    userTypeId: number = 0;
    userType: string = "";
}

class floorModal {
    id: number = 0;
    floorNo: string = "";
}

class userDetailsModal {
    userId: number = 0;
    name: string = "";
    email: string = "";
    seatNo: string = "";
    floorId: number = 0;
    floorNo: string = "";
    userTypeId: number = 0;
    userType: string = "";
}

import { Component, ViewChild, ElementRef } from '@angular/core';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    @ViewChild('btnOpenPopup')
    //public btnOpenPopup: ElementRef;

    public popupHeader: string = "";
    public popupBody: string = "";
    public hideMainNav: boolean = false;

    constructor() {
    }

    ShowPopup() {
        //this.btnOpenPopup.nativeElement.click();
    }

    showMainNav() {
        this.hideMainNav = true;
    }
}

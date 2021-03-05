import { ApplicationInitStatus, Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})

export class HomeComponent implements OnInit {
  
  _accessToken: string = "";

  constructor(private _routes: ActivatedRoute) { }

  ngOnInit(): void {
    this._routes.data.subscribe((response: any) => {
      this._accessToken = response.token.accessToken;
    })
  }
}

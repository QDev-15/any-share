import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderMenuComponent } from "./components/header-menu/header-menu.component";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  imports: [HeaderMenuComponent]
})
export class AppComponent {
  title = 'share-web';
}

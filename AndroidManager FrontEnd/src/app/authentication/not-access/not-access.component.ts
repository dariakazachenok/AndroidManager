import {Component} from '@angular/core';

@Component({
  selector: 'not-access-app',
  template: `<h3>Sorry, but you don't have access</h3>
  <div class="form-group">
    <a [routerLink]="['']" class="btn btn-link">Return to Home</a>
  </div>`
})
export class NotAccessComponent {
}


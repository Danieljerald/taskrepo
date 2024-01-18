import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { HotelbookingComponent } from '../hotelbooking/hotelbooking.component';

@Component({
  selector: 'app-booking',
  standalone: true,
  imports: [RouterLink,RouterOutlet,HotelbookingComponent],
  templateUrl: './booking.component.html',
  styleUrl: './booking.component.css'
})
export class BookingComponent {
show:boolean=false;

showForm()
{
  this.show=!this.show;
}
}



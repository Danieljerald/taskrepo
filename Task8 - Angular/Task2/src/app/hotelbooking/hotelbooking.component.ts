import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';

@Component({
  selector: 'app-hotelbooking',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './hotelbooking.component.html',
  styleUrl: './hotelbooking.component.css'
})
export class HotelbookingComponent {

  roomType: string = '';
  numberRooms :number=0;
  numberPersons: number=0;
  numberChildren: number=0;
  restrauntFacility: string ='';
  cost: number =0;
  

  onSubmit(form:NgForm){
    console.log(form);
    this.roomType = form.value.roomType;
    this.numberRooms = form.value.numberRooms;
    this.numberChildren = form.value.numberChildren;
    this.numberPersons = form.value.numberPersons;
    this.restrauntFacility = form.value.restrauntFacility;

    if(this.roomType == 'Room')
    {
      console.log(this.restrauntFacility);
      if(this.restrauntFacility == "Yes")
      {
        this.cost = (this.numberRooms*1200) + (this.numberChildren*300) + (this.numberPersons*500);
      }
      else{
        this.cost = (this.numberRooms*1000) + (this.numberChildren*300) + (this.numberPersons*500);
      }
    }
    
    else(this.roomType == 'Suite')
    {
      if(this.restrauntFacility == "Yes")
      {
        this.cost = (this.numberRooms*1500) + (this.numberChildren*400) + (this.numberPersons*600);
      }
      else{
        this.cost = (this.numberRooms*1200) + (this.numberChildren*400) + (this.numberPersons*600);
      }
    }
}
}

import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent {
  title = 'ToDo-App';

  filter: "all" | "active" | "done" = "all";

  allItems = [
    {description: "Learn Angular", done: false},
    {description: "Create Blueprint for Webside", done: false},
    {description: "Create Webside", done: false },
    {description: "Link with Database", done: false },
  ];

  get items(){
    if(this.filter === "all"){
      return this.allItems;
    }
    return this.allItems.filter((item) =>
      this.filter === "done" ? item.done : !item.done
    );
  }

  addItem(description: string){
    this.allItems.unshift({
      description,
      done: false
    });
  }

}

import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { RouterLink } from '@angular/router';
import { PersonService } from '../../../Services/Person/person.service';
import { Person } from '../../../Models/Person/Person.models';
import { MatTableModule } from '@angular/material/table';

@Component({
  selector: 'app-list-person',
  imports: [MatButtonModule, RouterLink, MatTableModule],
  templateUrl: './list-person.component.html',
  styleUrl: './list-person.component.css'
})
export class ListPersonComponent {
  personService = inject(PersonService);
  persons?: Person[];
  columns = ['full_name', 'phone_number', 'active', 'action']

  constructor() {
    this.getAll();
  }

  public getAll() {
    this.personService.getAllPersons().subscribe(persons => {
      this.persons = persons;
    });
  }
}

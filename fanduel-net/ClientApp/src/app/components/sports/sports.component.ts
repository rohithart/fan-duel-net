import { Component, OnInit } from '@angular/core';
import { Sport } from 'src/app/models/Sport';
import { SportService } from 'src/app/services/sport.service';

@Component({
  selector: 'app-sports',
  templateUrl: './sports.component.html',
  styleUrls: ['./sports.component.scss']
})
export class SportsComponent implements OnInit{
  sports: Sport[] = [];

  constructor(private sportsService: SportService) {}

  ngOnInit(): void {
    this.refresh();
  }

  refresh() {
    this.getData();
  }

  private getData() {
    this.sportsService.getAllSports().subscribe((data) => {
      this.sports = data.sort((a,b) => a.name.localeCompare(b.name));
    })
  }
}

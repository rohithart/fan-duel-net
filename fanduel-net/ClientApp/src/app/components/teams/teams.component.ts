import { Component, OnInit } from '@angular/core';
import { Team } from 'src/app/models/Team';
import { TeamService } from 'src/app/services/team.service';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.scss']
})
export class TeamsComponent implements OnInit {
  teams: Team[] = [];

  constructor(private teamsService: TeamService) {}

  ngOnInit(): void {
    this.refresh();
  }

  refresh() {
    this.getData();
  }

  private getData() {
    this.teamsService.getAllTeams().subscribe((data) => {
      this.teams = data;
    })
  }
}

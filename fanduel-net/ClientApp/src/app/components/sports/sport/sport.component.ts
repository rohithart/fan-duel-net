import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Sport } from 'src/app/models/Sport';
import { Team } from 'src/app/models/Team';
import { SportService } from 'src/app/services/sport.service';
import { TeamService } from 'src/app/services/team.service';

@Component({
  selector: 'app-sport',
  templateUrl: './sport.component.html',
  styleUrls: ['./sport.component.scss']
})
export class SportComponent implements OnInit {
  sportId = '';
  sport?: Sport;
  teams: Team[] = [];

  constructor(
    private route: ActivatedRoute,
    private sportsService: SportService,
    private teamsService: TeamService) {}

  ngOnInit(): void {
    this.sportId = this.route.snapshot.params['id'] || '';
    this.refresh();
  }

  refresh() {
    this.getData();
  }

  private getData() {
    this.sportsService.getSport(this.sportId).subscribe((sport) => {
      if(sport != null) {
        this.sport = sport;
        this.getTeams(sport);
      }
    })
  }

  private getTeams(sport: Sport) {
    this.teamsService.getAllTeamsFor(sport.id).subscribe((data) => {
      this.teams = data;
    })
  }
}

import { Component, OnInit } from '@angular/core';
import { ForumService } from '../services/forum.service';

@Component({
  selector: 'lib-forum',
  template: ` <p>forum works!</p> `,
  styles: [],
})
export class ForumComponent implements OnInit {
  constructor(private service: ForumService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}

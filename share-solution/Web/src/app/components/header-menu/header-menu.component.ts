import { Component, OnInit } from '@angular/core';
import { ICategory } from '../../models/category';
import { UtilitiesService } from '../../Commons/UtilitiesService';
import { CommonModule, NgFor } from '@angular/common';

@Component({
  selector: 'header-menu',
  imports: [CommonModule],
  standalone: true,
  templateUrl: './header-menu.component.html',
  styleUrl: './header-menu.component.scss'
})
export class HeaderMenuComponent implements OnInit {
  public categories: ICategory[] = [];

  constructor(
    private utilitiesService: UtilitiesService
  ) {

  }

  ngOnInit(): void {
      this.getData();
  }
  private getData() {
    this.categories = [
      { id: this.utilitiesService.getGuildId(), name: 'Home', childs: [], parent: null },
      { id: this.utilitiesService.getGuildId(), name: 'Product', childs: [], parent: null },
      { id: this.utilitiesService.getGuildId(), name: 'About Us', childs: [], parent: null },
      { id: this.utilitiesService.getGuildId(), name: 'Services', childs: [], parent: null },
    
      // Item 5 có cấp 2 và 3
      {
        id: this.utilitiesService.getGuildId(),
        name: 'Blog',
        parent: null,
        childs: [
          {
            id: this.utilitiesService.getGuildId(),
            name: 'Tech',
            parent: null, // Bạn có thể cập nhật parent nếu cần
            childs: [
              { id: this.utilitiesService.getGuildId(), name: 'AI', childs: [], parent: null },
              { id: this.utilitiesService.getGuildId(), name: 'Blockchain', childs: [], parent: null }
            ]
          },
          {
            id: this.utilitiesService.getGuildId(),
            name: 'Lifestyle',
            childs: [],
            parent: null
          }
        ]
      },
    
      // Item 6 có cấp 2 và 3
      {
        id: this.utilitiesService.getGuildId(),
        name: 'Shop',
        parent: null,
        childs: [
          {
            id: this.utilitiesService.getGuildId(),
            name: 'Clothing',
            childs: [
              { id: this.utilitiesService.getGuildId(), name: 'Men', childs: [], parent: null },
              { id: this.utilitiesService.getGuildId(), name: 'Women', childs: [], parent: null }
            ],
            parent: null
          },
          {
            id: this.utilitiesService.getGuildId(),
            name: 'Accessories',
            childs: [],
            parent: null
          }
        ]
      },
    
      // Item 7 có cấp 2 và 3
      {
        id: this.utilitiesService.getGuildId(),
        name: 'Contact',
        parent: null,
        childs: [
          {
            id: this.utilitiesService.getGuildId(),
            name: 'Support',
            childs: [
              { id: this.utilitiesService.getGuildId(), name: 'Email', childs: [], parent: null },
              { id: this.utilitiesService.getGuildId(), name: 'Phone', childs: [], parent: null }
            ],
            parent: null
          },
          {
            id: this.utilitiesService.getGuildId(),
            name: 'Locations',
            childs: [],
            parent: null
          }
        ]
      }
    ];
  }
}

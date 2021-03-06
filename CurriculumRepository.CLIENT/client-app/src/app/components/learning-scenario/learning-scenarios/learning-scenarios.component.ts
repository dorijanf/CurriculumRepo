import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Observable } from 'rxjs';
import { QueryParameters } from 'src/app/models/QueryParameters';
import { LsListDTO } from 'src/app/models/scenario/LsListDTO';
import { DataService } from 'src/app/services/data.service';
import { PaginationService } from 'src/app/services/pagination.service';
import { ScenariosService } from 'src/app/services/scenarios.service';
import { faSearch } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-learning-scenarios',
  templateUrl: './learning-scenarios.component.html',
  styleUrls: ['./learning-scenarios.component.scss']
})
export class LearningScenariosComponent implements OnInit {
  faSearch = faSearch;
  resultsForm = this.fb.group({
    scenarios: [''],
    teachingSubjects: [''],
    orderBy: [''],
  })

  searchForm = this.fb.group({
    search: [''],
  })

  pageNo: any = 1;
  pageNumber: boolean[] = [];
  orderBy: any = 'lsname';
  scenarios$: Observable<LsListDTO[]>;
  scenariosPerPage: any = 10;
  scenariosPerPageResults: number[];
  teachingSubjects: any;

  pageField = [];
  exactPageList: any;
  paginationData: number;
  totalScenariosCount: number;
  lsName: string;
  lsGrade: number;
  keyword: string;
  @Input() teachingSubjectId: number;
  pageOfItems: any[];
  constructor(private fb: FormBuilder, private scenariosService: ScenariosService, public paginationService: PaginationService, private dataService: DataService) { }

  ngOnInit(): void {
    this.pageNumber[0] = true;
    this.getDropdowns();
    this.loadScenarios();
  }

  getDropdowns() {
    this.dataService.getTeachingSubjects().subscribe(teachingSubject => {
      this.teachingSubjects = teachingSubject;
    })

    this.scenariosPerPageResults = [10, 20, 50, 100, 150, 200];
  };

  showScenariosByPageNumber(page, i) {
    this.pageNumber = [];
    this.pageNumber[i] = true;
    this.pageNo = page;
    this.loadScenarios();
  }

  totalNoOfPages() {
    this.paginationData = Number(this.totalScenariosCount / this.scenariosPerPage);
    let tempPageData = this.paginationData.toFixed();
    if (Number(tempPageData) < this.paginationData) {
      this.exactPageList = Number(tempPageData) + 1;
      this.paginationService.exactPageList = this.exactPageList;
    } else {
      this.exactPageList = Number(tempPageData);
      this.paginationService.exactPageList = this.exactPageList;
    }
    this.paginationService.pageOnLoad();
    this.pageField = this.paginationService.pageField;
  }

  loadScenarios() {
    let queryParameters: QueryParameters = {
      PageSize: this.scenariosPerPage,
      PageNumber: this.pageNo,
      TeachingSubjectId: this.teachingSubjectId,
      Lsname: this.lsName,
      Keyword: this.keyword,
      OrderBy: this.orderBy,
      Lsgrade: this.lsGrade,
    }
    this.scenarios$ = this.scenariosService.getScenarios(queryParameters);
    this.paginationService.temppage = 0;
    this.getScenariosCount();
  }

  getScenariosCount() {
    let queryParameters: QueryParameters = {
      PageSize: this.scenariosPerPage,
      PageNumber: this.pageNo,
      TeachingSubjectId: this.teachingSubjectId,
      Lsname: this.lsName,
      Keyword: this.keyword,
      OrderBy: this.orderBy,
      Lsgrade: this.lsGrade,
    }
    this.scenariosService.getScenariosCount(queryParameters).subscribe(data => {
      this.totalScenariosCount = data['scenariosCount'];
      this.totalNoOfPages();
    });
  }

  setOrderBy() {
    this.orderBy = this.resultsForm.get('orderBy').value;
    this.loadScenarios();
  }

  setNumberOfResults() {
    this.scenariosPerPage = this.resultsForm.get('scenarios').value;
    this.loadScenarios();
  }

  setTeachingSubject() {
    this.teachingSubjectId = this.resultsForm.get('teachingSubjects').value === '' ? null : this.resultsForm.get('teachingSubjects').value;
    this.loadScenarios();
  }

  setSearchText() {
    this.keyword = this.searchForm.get('search').value === '' ? null : this.searchForm.get('search').value;
    this.lsName = this.searchForm.get('search').value === '' ? null : this.searchForm.get('search').value;
    this.loadScenarios();
    this.keyword = null;
    this.lsName = null;
  }

  getBackgroundColor(teachingSubject) {
    let color = "#888";
    switch (teachingSubject) {
      case 1: {
        color = "lawngreen";
        break;
      }
      case 2: {
        color = "aquamarine";
        break;
      }
      case 3: {
        color = "turquoise";
        break;
      }
      case 4: {
        color = "coral";
        break;
      }
      case 5: {
        color = "cyan";
        break;
      }
      case 6: {
        color = "darkorange";
        break;
      }
      case 7: {
        color = "darkseagreen";
        break;
      }
      case 8: {
        color = "goldenrod";
        break;
      }
      case 9: {
        color = "mediumaquamarine";
        break;
      }
      case 10: {
        color = "plum";
        break;
      }
      case 11: {
        color = "salmon";
        break;
      }
      case 12: {
        color = "violet";
        break;
      }
      case 13: {
        color = "darkgreen";
        break;
      }
      case 14: {
        color = "springgreen";
        break;
      }
      default: {
        break;
      }
    }
    return color;
  }

  getIcon(teachingSubject) {
    let path = ''
    switch (teachingSubject) {
      case 1: {
        path = 'assets/icons/matematika.png';
        break;
      }
      case 2: {
        path = 'assets/icons/hrvatski.png';
        break;
      }
      case 3: {
        path = 'assets/icons/engleski.png';
        break;
      }
      case 4: {
        path = 'assets/icons/talijanski.png';
        break;
      }
      case 5: {
        path = 'assets/icons/njemački.png';
        break;
      }
      case 6: {
        path = 'assets/icons/priroda.png';
        break;
      }
      case 7: {
        path = 'assets/icons/informatika.png';
        break;
      }
      case 8: {
        path = 'assets/icons/tjelesni.png';
        break;
      }
      case 9: {
        path = 'assets/icons/likovni.png';
        break;
      }
      case 10: {
        path = 'assets/icons/glazbeni.png';
        break;
      }
      case 11: {
        path = 'assets/icons/srz.png';
        break;
      }
      case 12: {
        path = '';
        break;
      }
      case 13: {
        path = '';
        break;
      }
      case 14: {
        path = '';
        break;
      }
      default: {
        break;
      }
    }
    return path;
  }


}

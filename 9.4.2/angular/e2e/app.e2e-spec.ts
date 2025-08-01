import { GroupManagementSystemTemplatePage } from './app.po';

describe('GroupManagementSystem App', function() {
  let page: GroupManagementSystemTemplatePage;

  beforeEach(() => {
    page = new GroupManagementSystemTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});

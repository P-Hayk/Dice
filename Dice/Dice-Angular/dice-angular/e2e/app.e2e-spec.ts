import { DiceAngularPage } from './app.po';

describe('dice-angular App', () => {
  let page: DiceAngularPage;

  beforeEach(() => {
    page = new DiceAngularPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});

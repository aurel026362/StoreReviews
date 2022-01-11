import { NgModule } from '@angular/core';

import { LinkifyPipe } from './linkify.pipe';

@NgModule({
    declarations: [LinkifyPipe],
    exports: [LinkifyPipe]
})
export class LinkifyModule { }

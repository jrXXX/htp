
import { Pipe, PipeTransform } from '@angular/core';
/*
 * umwandelt alle http to https image urls
*/
@Pipe({name: 'transformBackendImagesPipe'})
export class transformBackendImagesPipe implements PipeTransform {
  transform(images: Array<any>): Array<any> {
    images = images.map( constImage => {

        let image = {
           ...constImage,
            "image": constImage.image.replace("http:", "https:"),
        }
        return image
      })

      return images;
  }
}

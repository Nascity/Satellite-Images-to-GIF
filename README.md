# Satellite Images to GIF (SItG)

Retrieves satellite images using KMA Open-API and converts them to a single GIF file with AnimatedGif package.

## Acknowledgements

 - [KMA Open-API](https://www.data.go.kr/data/15058167/openapi.do) by Korea Meteorological Administration
 - [AnimatedGif](https://github.com/mrousavy/AnimatedGif) package by mrousavy
 
## Bugs & Todos

- Add a feature to change gif speed.

- Program is not functioning when optional arguments are not passed.

## Usage (WIP ─ needs to be worked on)

```
===== USAGE

sitg --data: <DATA> --area: <AREA> --time: <TIME>
     --interval: <INTERVAL> --filename: <FILENAME> --directory: <DIRECTORY>

## DATA
ir: 적외영상
vi: 가시영상
wv: 수증기영상
sw: 단파적외영상
rbgt: RGB컬러
rgbdn: RGB주야간합성

## AREA
fd: 전구
ea: 동아시아
ko: 한반도

## TIME
YYYYMMDD 양식으로 입력

## INTERVAL (Optional)
시간 간격(분)을 2의 배수로 입력
(기본값은 2분)

## FILENAME (Optional)
출력할 파일명 입력
(확장자명 없이)

## DIRECTORY (Optional)
출력할 폴더명 입력

===== USAGE
```

## Demo

Options:

```
stig 1 10 ir ko 20221001 16 out output
```

Output:

![output](img/output_resized.gif)

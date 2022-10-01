# Satellite images to GIF (WIP)

Retrieves satellite images using KMA Open-API and converts them to a single GIF file with AnimatedGif package.

## Acknowledgements

 - [KMA Open-API](https://www.data.go.kr/data/15058167/openapi.do) by Korea Meteorological Administration
 - [AnimatedGif package](https://github.com/mrousavy/AnimatedGif) by mrousavy
 
## Bugs & Todos

- Add a feature to change gif speed.

- Program is not functioning when optional arguments are not passed.

## Usage (WIP ─ needs to be worked on)

```
stig <pageNo> <numOfRows> <data> <area> <time> <interval> <(opt) filename> <(opt) directory>
```
**data**
- ir: 적외영상
- vi: 가시영상
- wv: 수증기영상
- sw: 단파적외영상
- rbgt: RGB컬러
- rgbdn: RGB주야간합성

**area**
- fd: 전구
- ea: 동아시아
- ko: 한반도

**time**
- YYYYMMDD 양식으로 입력

**interval**
- 시간 간격(분)을 2의 배수로 입력 (기본값은 2분)

## Demo

Options:

```
stig 1 10 ir ko 20221001 16 out output
```

Output:

![output](img/output_resized.gif)

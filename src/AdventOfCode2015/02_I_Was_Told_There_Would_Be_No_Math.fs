module IWasToldThereWouldBeNoMath
  let private scanLine (line: string) =
    line.Split("x")
    |> Seq.map int
    |> Seq.toList
  
  let calculateWrappingPaperAmount (lines: string) =
    let parseLine (line: string) =
      let arr = scanLine line
      
      let sides = [| arr[0] * arr[1]; arr[0] * arr[2]; arr[1] * arr[2] |]
      let area = 2 * Seq.sum sides
      area + Seq.min sides
      
    
    lines.Split('\n')
    |> Seq.map parseLine
    |> Seq.reduce (+)
    
  let calculateRibbonLength (lines: string) =
    let parseLine (line: string) =
      let arr = scanLine line
      
      let volume = Seq.reduce (*) arr
      let sideLength = (Seq.sum arr - Seq.max arr) * 2
      
      volume + sideLength

    lines.Split('\n')
    |> Seq.map parseLine
    |> Seq.reduce (+)

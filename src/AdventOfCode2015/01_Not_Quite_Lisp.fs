namespace AdventOfCode2015

module NotQuiteLisp =
  let private floorToValue c =
    match c with
    | '(' -> 1
    | ')' -> -1
    | _ -> 0

  let findFinalFloor instructions =
    instructions
    |> Seq.map floorToValue
    |> Seq.fold (+) 0
    
  let findFirstBasementFloor instructions =
    instructions
    |> Seq.map floorToValue
    |> Seq.scan (+) 0
    |> Seq.findIndex (fun l -> l < 0)

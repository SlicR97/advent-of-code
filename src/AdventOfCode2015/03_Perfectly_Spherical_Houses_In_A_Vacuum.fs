module PerfectlySphericalHousesInAVacuum

type private Cell =
  { x: int
    y: int }

let private traverse chars =
  chars
  |> Seq.fold (fun agg c ->
    let cell = List.head agg
    match c with
    | '>' -> { cell with x = cell.x + 1 } :: agg
    | '<' -> { cell with x = cell.x - 1 } :: agg
    | '^' -> { cell with y = cell.y + 1 } :: agg
    | 'v' -> { cell with y = cell.y - 1 } :: agg
    | _ -> agg ) [ { x = 0; y = 0 } ]

let numberOfHousesReceivingPresents (input: string) =
  input
  |> traverse
  |> Seq.distinctBy (fun c -> c.x, c.y)
  |> Seq.length

let numberOfHousesWithRobotSanta (input: string) =
  let everySecond i l =
    l
    |> Seq.skip i
    |> Seq.indexed
    |> Seq.filter (fun (i, _) -> i % 2 = 0)
    |> Seq.map snd

  let firstList = everySecond 0 input
  let secondList = everySecond 1 input
  
  let firstRoute = traverse firstList
  let secondRoute = traverse secondList
  
  firstRoute
  |> Seq.append secondRoute
  |> Seq.distinctBy (fun c -> c.x, c.y)
  |> Seq.length

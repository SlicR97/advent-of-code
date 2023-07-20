module TheIdealStockingStuffer.Tests

open NUnit.Framework
open FsUnit

module AcceptanceTest =
  [<Test>]
  let ``Acceptance Test For Part One`` () =
    let result = bruteForceMD5 "yzbqklnj"
    result |> should equal 282749

  [<Test>]
  let ``Acceptance Test For Part Two`` () =
    let result = bruteForceMD52 "yzbqklnj"
    result |> should equal 9962624

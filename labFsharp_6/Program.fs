open FParsec



 //Разбор выражения
 //Создаем опережающее описание для парсера
let pstring_ws s = spaces >>. pstring s .>> spaces
let float_ws = spaces >>. pfloat .>> spaces
let a_plus_b = pipe5 (pstring_ws "(") (float_ws) (pstring_ws "+") (float_ws) (pstring_ws ")") (fun _ x _ y _ -> x + y)
printfn "%A" (run a_plus_b " ( 2 + 3 ) ")

 //Произвольная комбинация букв a и b
let a_or_b = many (pstring "a" <|> pstring "b")
printfn "%A" (run a_or_b "abbbabba")
printfn "%A" (run a_or_b "bbbbbbaaaaaaabbbbabbabba")



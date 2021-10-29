const PassageViewComponent = ({ bookName, chapterNumber, passageStart, passageEnd, chapterCount, verseCount}) => {

    const [dataVerses, setVerses] = React.useState([]);
    const [book, setBook] = React.useState(bookName);
    const [chapter, setChapter] = React.useState(chapterNumber);
    const [start, setStart] = React.useState(passageStart);
    const [end, setEnd] = React.useState(passageEnd);
    const [maxChapter, setMaxChapter] = React.useState(chapterCount);
    const [maxVerse, setMaxVerse] = React.useState(verseCount);

     React.useEffect(() => {
         fetch(`/Home/PassageUpdate?bookID=${book}&chapterNumber=${chapter}&verseStart=${start}&verseEnd=
                ${end}`).then((response) => {
                    if (response.ok) {
                        return response.json();
                    }
                }).then((data) => {
                    setVerses(data.Passage.Verses);
                    setMaxChapter(data.MaxChapter);
                    setMaxVerse(data.MaxVerse);
                })
    }, [start, end, chapter]);


    const valuesArray = dataVerses;


    function savePassage(bookID, chap, startV, endV) {

        var value = {
            Book: bookID ,
            Chapter: parseInt(chap) ,
            PassageStart: parseInt(startV) ,
            PassageEnd: parseInt(endV)
        }
        let res = fetch('/Home/AddPassageToUserPassages', {
            method: "POST",
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(value)
        });
    }



    return (
        <>
            <div className="row">
                <div className="col-md-12 text-center">
                    <h1>{bookName} - Chapter {chapter} : Verse {start} - {end}</h1>
                </div>
            </div>
            <div className="row">
                <div className="col-md-12 text-center">
                    <label htmlFor="chapter">Chapter</label>
                    <input min="1" max={maxChapter} type="number" name="chapter" value={chapter}
                        onKeyDown={(event) => { event.preventDefault(); }}
                        onChange={(event) => { setStart(1); setEnd(1); setChapter(event.target.value) }} />
                    <label htmlFor="start">Passage Start</label>
                    <input min="1" max={end} type="number" name="start" value={start}
                        onKeyDown={(event) => {event.preventDefault(); }} onChange={(event) => setStart(event.target.value)} />
                    <label htmlFor="end">Passage End</label>
                    <input min={start} max={maxVerse} type="number" name="end" value={end}
                        onKeyDown={(event) => { event.preventDefault();}} onChange={(event) => setEnd(event.target.value)} />
                </div>
            </div>
            <div className="row">
                <div className="col-md-12">
                    <p>
                        {
                            valuesArray.map(verse => (
                                <span key={verse.verseNumber}>{verse.verseNumber} {verse.Text} </span>
                            ))
                        }
                    </p>
                </div>
            </div>
            <div className="row">
                <div className="col-md-12">
                    <button onClick={() => savePassage(bookName, chapter, start, end)} type="submit">Save Passage for Later</button>
                </div>
            </div>
		</>
	)
}

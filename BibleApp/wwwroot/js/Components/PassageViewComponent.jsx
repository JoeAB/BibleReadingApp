const PassageViewComponent = ({ bookName, chapterNumber, passageStart, passageEnd }) => {

    const [dataVerses, setVerses] = React.useState([]);
    const [book, setBook] = React.useState(bookName);
    const [chapter, setChapter] = React.useState(chapterNumber);
    const [start, setStart] = React.useState(passageStart);
    const [end, setEnd] = React.useState(passageEnd);


     React.useEffect(() => {
         fetch(`/Home/PassageUpdate?bookID=${book}&chapterNumber=${chapter}&verseStart=${start}&verseEnd=
                ${end}`).then((response) => {
                    if (response.ok) {
                        return response.json();
                    }
                }).then((data) => {
                    setVerses(data);
                })
    }, [start, end]);


    const valuesArray = dataVerses;

    return (
        <>

            <div className="row">
                <div className="col-md-12 text-center">
                    <h1>{bookName} - Chapter {chapterNumber} : Verse {start} - {end}</h1>
                </div>
            </div>
            <div className="row">
                <div className="col-md-12 text-center">
                    <input type="text" name="start" value={start} onChange={(event) => setStart(event.target.value)} />
                    <input type="text" name="end" value={end} onChange={(event) => setEnd(event.target.value)} />
                </div>
            </div>
            <div className="row">
                <div className="col-md-12">
                    <p>
                        {
                            valuesArray.map(verse => (
                                <span>{verse.verseNumber} {verse.Text} </span>
                            ))
                        }
                    </p>
                </div>
            </div>
		</>
	)
}

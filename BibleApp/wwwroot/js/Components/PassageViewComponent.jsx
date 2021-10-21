const PassageViewComponent = ({ bookName, chapterNumber, passageStart, passageEnd, passageData }) => {
    const valuesArray = JSON.parse(passageData);

    return (
		<>
            <div className="row">
                <div className="col-md-12 text-center">
                    <h1>{bookName} - Chapter {chapterNumber} : Verse {passageStart} - { passageEnd }</h1>
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

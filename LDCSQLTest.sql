SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
SELECT
	bus.Business
	,ISNULL(pre.StreetNo, '') AS 'StreetNo'
	,pre.Street
	,pre.PostCode
	,foo.Count AS 'FootFallCount'
FROM #Businesses bus
LEFT JOIN #Premises pre ON pre.BusinessId = bus.Id
LEFT JOIN (SELECT ff.PremisesId, Sum(ff.Count) AS 'Count' 
	FROM #FootFall ff GROUP BY ff.PremisesId) foo ON foo.PremisesId = pre.Id

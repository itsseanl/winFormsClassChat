SELECT CourseName
FROM CollegeInfo
WHERE (SELECT COUNT(*)
		FROM CollegeInfo
		WHERE CollegeName = CollegeName
		AND CourseName = CourseName) >1
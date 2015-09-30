<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <head>
        <title>XML Basics Homework</title>
        <style>
          th, td {
            border: 1px solid black;
            text-align: center;
            padding: 5px;
          }
          table {
            border-collapse: collapse;
          }
        </style>
      </head>
      <body>
        <h1>Students</h1>
        <table>
          <tr>
            <th>Name</th>
            <th>Sex</th>
            <th>Birthdate</th>
            <th>Phone</th>
            <th>Email</th>
            <th>Course</th>
            <th>Speialty</th>
            <th>Faculty number</th>
            <th>Exams</th>
          </tr>
          <xsl:for-each select="/students/student">
            <tr>
              <td><xsl:value-of select="name"/></td>
              <td><xsl:value-of select="sex"/></td>
              <td><xsl:value-of select="birthdate"/></td>
              <td><xsl:value-of select="phone"/></td>
              <td><xsl:value-of select="mail"/></td>
              <td><xsl:value-of select="course"/></td>
              <td><xsl:value-of select="specialty"/></td>
              <td><xsl:value-of select="facultynumber"/></td>
              <td>
                <table>
                  <tr>
                    <th>Name</th>
                    <th>Tutor</th>
                    <th>Score</th>
                  </tr>
                  <xsl:for-each select="exams/exam">
                    <tr>
                      <td><xsl:value-of select="name"/></td>
                      <td><xsl:value-of select="tutor"/></td>
                      <td><xsl:value-of select="score"/></td>
                    </tr>
                  </xsl:for-each>
                </table>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
